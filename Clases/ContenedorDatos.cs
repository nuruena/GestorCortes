using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Gestor_Cortes.Clases
{
    public static class ContenedorDatos
    {
        public static List<HojaSeleccionada> HojasSeleccionadas = new List<HojaSeleccionada>();
        public static List<Corte> listaCortes = new List<Corte>();
        public static List<Corte> cortesDescartados = new List<Corte>();
        public static List<Corte> cortesDescartadosAmostrar = new List<Corte>();
        public static List<string> terminalesDeEsteProceso = new List<string>();
        public static List<Corte> listaCortesAMostrar = new List<Corte>();
        public static List<Corte> listaCortesAMostrarAcomodadas = new List<Corte>();
        public static List<int> numerosDeOrden = new List<int>();
        public static List<int> seTerminaron = new List<int>();
        public static List<string> rutas = new List<string>();
        public static int indiceObservacion = 0;
        public static string observacion = "";
        public static bool esRestauracion = false;
        public static bool esRestauracionAnterior = false;
        public static bool agregandoDatos = false;
        public static bool observacionObligatoria = false;
        public static bool huboCambiosCancelados = false;
        public static bool huboCambiosExcluidos = false;
        public static string nombreProceso = "";
        public static bool estoyViendo = false;


        public static void buscarCortesDeHojasSeleccionadas()
        {
            for (int i = 0; i < HojasSeleccionadas.Count; i++)
            {
                buscarCortesEnUnaHoja(HojasSeleccionadas[i]);
            }
        }

        public static void buscarCortesEnUnaHoja(HojaSeleccionada hoja)
        {
            sumarNumOrdenYRuta(hoja.NumOrden, hoja.Ruta);
            FileInfo fi = new FileInfo(hoja.Ruta);
            ExcelPackage excelPackage = new ExcelPackage(fi);
            for (int i = 1; i < excelPackage.Workbook.Worksheets.Count + 1; i++)
            {
                int fila = 10;
                while (excelPackage.Workbook.Worksheets[i].Cells["B" + fila.ToString()].Value != null & fila < 72)
                {
                    Corte nuevoCorte = new Corte(
                                hoja.NumOrden,
                                ObtenerDatoDeCelda(i, "B", fila.ToString()),
                                hoja.cantidad,
                                ObtenerDatoDeCelda(i, "C", fila.ToString()),
                                ObtenerDatoDeCelda(i, "D", fila.ToString()),
                                ObtenerDatoDeCelda(i, "E", fila.ToString()),
                                ObtenerDatoDeCelda(i, "G", fila.ToString()),
                                ObtenerDatoDeCelda(i, "H", fila.ToString()),
                                ObtenerDatoDeCelda(i, "I", fila.ToString()),
                                ObtenerDatoDeCelda(i, "J", fila.ToString()),
                                ObtenerDatoDeCelda(i, "O", fila.ToString()),
                                ObtenerDatoDeCelda(i, "N", fila.ToString()),
                                ObtenerDatoDeCelda(i, "M", fila.ToString()),
                                ObtenerDatoDeCelda(i, "L", fila.ToString()),
                                ObtenerDatoDeCelda(i, "K", fila.ToString()),
                                "",
                                "",
                                ObtenerDatoDeCelda(i, "A", "5").Remove(0, 9),
                                ObtenerDatoDeCelda(i, "E", "5").Remove(0, 10),
                                ObtenerDatoDeCelda(i, "P", fila.ToString())
                                );
                    descartoOIncluyo(nuevoCorte);
                    fila += 1;
                }
            }

            string ObtenerDatoDeCelda(int numhoja, string col, string fil)
            {
                if (excelPackage.Workbook.Worksheets[numhoja].Cells[col + fil].Value != null)
                {
                    return excelPackage.Workbook.Worksheets[numhoja].Cells[col + fil].Value.ToString();
                }
                return "";
            }
        }

        public static void DarVueltaTerminales(int i, List<Corte> listaEnDondeDarVuelta)
        {
            string despU1aux = listaEnDondeDarVuelta[i].despunteU1;
            string despT1aux = listaEnDondeDarVuelta[i].despunteT1;
            string ident1aux = listaEnDondeDarVuelta[i].identifYDistancia1;
            string term1aux = listaEnDondeDarVuelta[i].terminal1;
            listaEnDondeDarVuelta[i].despunteU1 = listaEnDondeDarVuelta[i].despunteU2;
            listaEnDondeDarVuelta[i].despunteT1 = listaEnDondeDarVuelta[i].despunteT2;
            listaEnDondeDarVuelta[i].identifYDistancia1 = listaEnDondeDarVuelta[i].identifYDistancia2;
            listaEnDondeDarVuelta[i].terminal1 = listaEnDondeDarVuelta[i].terminal2;
            listaEnDondeDarVuelta[i].despunteU2 = despU1aux;
            listaEnDondeDarVuelta[i].despunteT2 = despT1aux;
            listaEnDondeDarVuelta[i].identifYDistancia2 = ident1aux;
            listaEnDondeDarVuelta[i].terminal2 = term1aux;
        }

        //Ordenar cortes cuando es un proceso nuevo (no cuando se agregan)
        public static List<Corte> OrdenarTodosLosCortes(List<Corte> cortesAAcomodar, int indicePrimeroSinEstado)
        {
            List<List<Corte>> listaDeListas = acomodarCortesObtenerTerminalesYcortes(cortesAAcomodar);
            //Obtengo los cortes sin terminales
            List<Corte> cortesSinTerminales = listaDeListas[0];
            //Obtengo los cortes con una sola terminal
            List<Corte> cortesConUnaSolaTerminal = listaDeListas[1];
            List<Corte> cortesOrdenados = OrdenarCortes(cortesAAcomodar);
            cortesOrdenados = acomodarLosCortesDeUnSoloTerminal(cortesOrdenados, cortesConUnaSolaTerminal);
            cortesOrdenados = acomodarLosCortesSinTerminal(cortesOrdenados, cortesSinTerminales);
            return cortesOrdenados;
        }

        //Ordenar cortes cuando se esta agregando a un proceso anterior
        public static void OrdenarTodosLosCortes(List<string> ultimosTerminales, List<Corte> cortesAAcomodar, int indicePrimerSinEstado, List<Corte> listaAMostrar)
        {
            List<List<Corte>> listaDeListas = acomodarCortesObtenerTerminalesYcortes(cortesAAcomodar);
            //Obtengo los cortes sin terminales
            List<Corte> cortesSinTerminales = listaDeListas[0];
            //Obtengo los cortes con una sola terminal
            List<Corte> cortesConUnaSolaTerminal = listaDeListas[1];
            List<Corte> cortesOrdenados = OrdenarCortes(ultimosTerminales, cortesAAcomodar, indicePrimerSinEstado - 1);
            acomodarLosCortesDeUnSoloTerminal(cortesOrdenados, cortesConUnaSolaTerminal, indicePrimerSinEstado - 1, ultimosTerminales, listaAMostrar);
            acomodarLosCortesSinTerminal(cortesSinTerminales, indicePrimerSinEstado - 1, listaAMostrar);
        }

        //Se va fijando en la lista que los cortes no tengan un terminal en 2 y ninguno en 1, o que si tienen terminales en los dos, los acomode alfabeticamente
        public static void acomodarComoCuandoCargasHoja(List<Corte> cortesAOrdenar)
        {
            for (int i = 0; i < cortesAOrdenar.Count; i++)
            {
                if ((cortesAOrdenar[i].terminal1 == "" & cortesAOrdenar[i].terminal2 != "") | 
                    (cortesAOrdenar[i].terminal1 != "" & cortesAOrdenar[i].terminal2 != "" & cortesAOrdenar[i].terminal1.CompareTo(cortesAOrdenar[i].terminal2) > 0))
                { DarVueltaTerminales(i, cortesAOrdenar); }
            }
        }

        public static List<List<Corte>> acomodarCortesObtenerTerminalesYcortes(List<Corte> cortesAOrdenar)
        {
            List<Corte> sinTerminales = new List<Corte>();
            List<Corte> conUnTerminal = new List<Corte>();
            List<List<Corte>> listaDeListas = new List<List<Corte>>();
            for (int i = 0; i < cortesAOrdenar.Count; i++)
            {
                if (cortesAOrdenar[i].terminal1 == "" & cortesAOrdenar[i].terminal2 == "")
                {
                    sinTerminales.Add(cortesAOrdenar[i]);
                    cortesAOrdenar[i] = null;
                }
                else if (cortesAOrdenar[i].terminal1 == "" | cortesAOrdenar[i].terminal2 == "")
                {
                    if (cortesAOrdenar[i].terminal1 == "" & cortesAOrdenar[i].terminal2 != "")
                    { DarVueltaTerminales(i, cortesAOrdenar); }
                    conUnTerminal.Add(cortesAOrdenar[i]);
                    cortesAOrdenar[i] = null;
                }
                else
                {
                    if (!terminalesDeEsteProceso.Contains(cortesAOrdenar[i].terminal1))
                    {terminalesDeEsteProceso.Add(cortesAOrdenar[i].terminal1);}
                    if (!terminalesDeEsteProceso.Contains(cortesAOrdenar[i].terminal2))
                    {terminalesDeEsteProceso.Add(cortesAOrdenar[i].terminal2);}
                    if (cortesAOrdenar[i].terminal1.CompareTo(cortesAOrdenar[i].terminal2) > 0)
                    {DarVueltaTerminales(i, cortesAOrdenar);}
                }
            }
            QuitarNullsDeLista(cortesAOrdenar);
            listaDeListas.Add(sinTerminales);
            listaDeListas.Add(conUnTerminal);
            return listaDeListas;
        }

        public static void sumarNumOrdenYRuta(int numOrden, string ruta)
        {
            if (!numerosDeOrden.Contains(numOrden))
            {
                numerosDeOrden.Add(numOrden);
                rutas.Add(ruta);
            }
        }

        public static List<string> ObtenerTerminalesExistentes(List<Corte> cortesAAcomodar)
        {
            List<string> terminales = new List<string>();
            for (int i = 0; i < cortesAAcomodar.Count; i++)
            {
                if (!terminales.Contains(cortesAAcomodar[i].terminal1))
                {
                    terminales.Add(cortesAAcomodar[i].terminal1);
                }
                if (!terminales.Contains(cortesAAcomodar[i].terminal2))
                {
                    terminales.Add(cortesAAcomodar[i].terminal2);
                }
            }
            if (terminales.Contains(""))
            {
                terminales.Remove("");
            }
            return terminales;
        }

        public static List<Corte> OrdenarCortesPorTerminal2(List<Corte> cortesPorOrdenar)
        {
            List<Corte> cortesOrdenadosPorTerminal2 = cortesPorOrdenar.OrderByDescending(x => x.terminal2).ToList();
            return cortesOrdenadosPorTerminal2;
        }

        public static List<Corte> OrdenarCortesPorTerminal1(List<Corte> cortesPorOrdenar)
        {
            List<Corte> cortesOrdenadosPorTerminal1 = cortesPorOrdenar.OrderByDescending(x => x.terminal1).ToList();
            return cortesOrdenadosPorTerminal1;
        }

        public static List<Corte> OrdenarCortesPorSeccion(List<Corte> cortesPorOrdenar)
        {
            List<Corte> cortesOrdenadosPorSeccion = cortesPorOrdenar.OrderBy(x => x.seccion).ToList();
            return cortesOrdenadosPorSeccion;
        }

        public static List<Corte> OrdenarCortesPorColor(List<Corte> cortesPorOrdenar)
        {
            List<Corte> cortesOrdenadosPorColor = cortesPorOrdenar.OrderBy(x => x.color).ToList();
            return cortesOrdenadosPorColor;
        }

        //Ordena la lista de cortes segun su longitud, dde manera descendente
        public static List<Corte> OrdenarCortesPorLongitud(List<Corte> cortesPorOrdenar)
        {
            List<Corte> cortesOrdenadosPorLongitud = cortesPorOrdenar.OrderByDescending(x => int.Parse(x.largo)).ToList();
            return cortesOrdenadosPorLongitud;
        }

        //Busca los cortes sin terminales, los saca de la lista de cortes y los añade a los cortes a mostrar ordenados por seccion

        public static List<Corte> obtenerCortesSinTerminales(List<Corte> cortesAAcomodar)
        {
            List<Corte> cortesSinTerminales = new List<Corte>();
            for (int i = 0; i < cortesAAcomodar.Count; i++)
            {
                if (cortesAAcomodar[i].terminal1 == "" & cortesAAcomodar[i].terminal2 == "")
                {
                    cortesSinTerminales.Add(cortesAAcomodar[i]);
                    cortesAAcomodar[i] = null;
                }
            }
            QuitarNullsDeLista(cortesAAcomodar);
            return cortesSinTerminales;
        }

        public static List<Corte> obtenerCortesConUnSoloTerminal(List<Corte> cortesAAcomodar)
        {
            List<Corte> cortesConUnSoloTerminal = new List<Corte>();
            for (int i = 0; i < cortesAAcomodar.Count; i++)
            {
                if (cortesAAcomodar[i].terminal1 != "" & cortesAAcomodar[i].terminal2 == "")
                {
                    cortesConUnSoloTerminal.Add(cortesAAcomodar[i]);
                    cortesAAcomodar[i] = null;
                }
            }
            QuitarNullsDeLista(cortesAAcomodar);
            return cortesConUnSoloTerminal;
        }

        //Ordena los cortes que tienen dos terminales de la lista
        public static List<Corte> OrdenarCortes(List<Corte> cortesAAcomodar)
        {
            if (terminalesDeEsteProceso.Count == 0) { return cortesAAcomodar; }
            List<Corte> listaOrdenada = new List<Corte>();
            List<Corte> cortesConDosTerminales = new List<Corte>();
            for (int i = terminalesDeEsteProceso.Count - 1; i > -1; i--)
            {
                //Obtengo los cortes con ese terminal (los que tienen solo esa y los que no) y los saco de listaCortes
                cortesConDosTerminales = ObtenerCortesConEsteTerminal(terminalesDeEsteProceso[i], cortesAAcomodar);
                //Quito este terminal de la lista de terminales que faltan
                terminalesDeEsteProceso[i] = null;
                //Agrupo los cortes con dos terminales
                cortesConDosTerminales = OrdenarCortesPorTerminal2(cortesConDosTerminales);
                //Dejo para lo ultimo un corte que me sirva (si hay)
                cortesConDosTerminales = AcomodarUltimoUtil(cortesConDosTerminales, cortesAAcomodar);
                //Ordeno por seccion y despues por color
                if (cortesConDosTerminales.Count != 0)
                {
                    cortesConDosTerminales = ordenarPorSeccionDesdeIndice(0, cortesConDosTerminales);
                    cortesConDosTerminales = ordenarPorColorDesdeIndice(0, cortesConDosTerminales);
                }
                //La terminal que deje a lo ultimo, la pongo siguiente para procesar en la lista de terminales
                if (cortesAAcomodar.Count != 0 & cortesConDosTerminales.Count != 0)
                {
                    if (cortesConDosTerminales.Last().terminal2 != "" & HayCorteConEsteTerminal(cortesConDosTerminales.Last().terminal2, cortesAAcomodar))
                    {
                        terminalesDeEsteProceso[terminalesDeEsteProceso.IndexOf(cortesConDosTerminales.Last().terminal2)] = null;
                        terminalesDeEsteProceso.Add(cortesConDosTerminales.Last().terminal2);
                    }
                }
                //Saco las terminales null ddel proceso
                terminalesDeEsteProceso.RemoveAll(x => x == null);
                //Agrego los cortes acomdoados a la lista ya ordenada
                AgregarCortesALista(listaOrdenada, cortesConDosTerminales);
            }
            terminalesDeEsteProceso.RemoveAll(x => x == null);
            return listaOrdenada;
        }

        public static List<Corte> OrdenarCortes(List<string> ultimosTerminales, List<Corte> cortesAAcomodar, int indicePrimeroSinEstado)
        {
            if (terminalesDeEsteProceso.Count == 0) { return cortesAAcomodar; }
            List<Corte> cortesConDosTerminales = new List<Corte>();
            List<Corte> cortesAcomodados = new List<Corte>();
            List<Corte> cortesConDosTerminalesFinales = new List<Corte>();
            List<Corte> nuevaListaAAcomodar = new List<Corte>();

            //Si hay algun corte que tenga las ultimas terminales
            int hayCortes = hayAlgunCorteConEstosDosTerminales(ultimosTerminales[0], ultimosTerminales[1], cortesAAcomodar);
            if (hayCortes != -1)
            {
                //Busca los cortes con esas dos temrinales, los ordena (si hay alguno con el mismo cable que el ultimo antes de agregar cortes, lo agrega a listacortesamostrar)
                cortesConDosTerminalesFinales = obtenerCortesConEstasTerminalesYEliminarlosDeListaCortes(ultimosTerminales[0], ultimosTerminales[1], cortesAAcomodar, hayCortes, indicePrimeroSinEstado);
                //Agrego los que quedan a la lista ordenada
                for (int i = 0; i < cortesConDosTerminalesFinales.Count; i++)
                {
                    cortesAcomodados.Add(cortesConDosTerminalesFinales[i]);
                    cortesConDosTerminalesFinales[i] = null;
                }
                QuitarNullsDeLista(cortesConDosTerminalesFinales);
            }

            //Sigo con el terminal1 o el 2? Depende de cual tiene cortes para seguir
            if (ultimosTerminales[0] != "" & HayCorteConEsteTerminal(ultimosTerminales[0], cortesAAcomodar))
            {
                terminalesDeEsteProceso[terminalesDeEsteProceso.IndexOf(ultimosTerminales[0])] = null;
                terminalesDeEsteProceso.Add(ultimosTerminales[0]);
                terminalesDeEsteProceso.RemoveAll(x => x == null);
            }
            else if (ultimosTerminales[1] != "" & HayCorteConEsteTerminal(ultimosTerminales[1], cortesAAcomodar))
            {
                terminalesDeEsteProceso[terminalesDeEsteProceso.IndexOf(ultimosTerminales[1])] = null;
                terminalesDeEsteProceso.Add(ultimosTerminales[1]);
                terminalesDeEsteProceso.RemoveAll(x => x == null);
            }
            for (int i = terminalesDeEsteProceso.Count - 1; i > -1; i--)
            {
                //Obtengo los cortes con ese terminal (los que tienen solo esa y los que no) y los saco de listaCortes
                cortesConDosTerminales = ObtenerCortesConEsteTerminal(terminalesDeEsteProceso[i], cortesAAcomodar);
                //Quito este terminal de la lista de terminales que faltan
                terminalesDeEsteProceso[i] = null;
                //Agrupo los cortes con dos terminales
                cortesConDosTerminales = OrdenarCortesPorTerminal2(cortesConDosTerminales);
                //Dejo para lo ultimo un corte que me sirva (si hay)
                cortesConDosTerminales = AcomodarUltimoUtil(cortesConDosTerminales, cortesAAcomodar);
                //Ordeno por seccion y despues por color
                if (cortesConDosTerminales.Count != 0)
                {
                    cortesConDosTerminales = ordenarPorSeccionDesdeIndice(0, cortesConDosTerminales);
                    cortesConDosTerminales = ordenarPorColorDesdeIndice(0, cortesConDosTerminales);
                }

                //La terminal que deje a lo ultimo, la pongo siguiente para procesar en la lista de terminales
                if (cortesConDosTerminales.Count != 0)
                {
                    if (cortesConDosTerminales.Last().terminal2 != "" & HayCorteConEsteTerminal(cortesConDosTerminales.Last().terminal2, cortesAAcomodar))
                    {
                        terminalesDeEsteProceso[terminalesDeEsteProceso.IndexOf(cortesConDosTerminales.Last().terminal2)] = null;
                        terminalesDeEsteProceso.Add(cortesConDosTerminales.Last().terminal2);
                    }
                }
                //Saco las terminales null ddel proceso
                terminalesDeEsteProceso.RemoveAll(x => x == null);
                //Pone los cortes acomodados en la lista a mostrar
                AgregarCortesALista(cortesAcomodados, cortesConDosTerminales);
            }
            return cortesAcomodados;
        }

        public static List<Corte> AcomodarUltimoUtil(List<Corte> cortesABuscarUltimoUtil, List<Corte> listaDondeVeoLoQueSigue)
        {
            //Si no quedan cortes, que devuelva la lista como estaba
            if (listaDondeVeoLoQueSigue.Count == 0) { return cortesABuscarUltimoUtil; }
            //Si si quedan cortes, que recorra la lista hasta encontrar un terminal que no se haya usado
            for (int i = 0; i < cortesABuscarUltimoUtil.Count; i++)
            {
                //Si encuentra uno, que deje todos los cortes con ese temrinal para lo ultimo
                if (HayCorteConEsteTerminal(cortesABuscarUltimoUtil[i].terminal2, listaDondeVeoLoQueSigue))
                {
                    List<Corte> listaAcomodada = new List<Corte>();
                    List<Corte> listaUltimosCortes = new List<Corte>();
                    for (int j = 0; j < cortesABuscarUltimoUtil.Count; j++)
                    {
                        if (cortesABuscarUltimoUtil[j].terminal2 == cortesABuscarUltimoUtil[i].terminal2)
                        {
                            listaUltimosCortes.Add(cortesABuscarUltimoUtil[j]);
                        }
                        else
                        {
                            listaAcomodada.Add(cortesABuscarUltimoUtil[j]);
                        }
                    }
                    AgregarCortesALista(listaAcomodada, listaUltimosCortes);
                    return listaAcomodada;
                }
            }
            //Si llega a este punto, es porque no tiene ningun terminal que no se haya usado aun, devuelve la lista como vino
            return cortesABuscarUltimoUtil;
        }

        public static List<Corte> AcomodarUltimoUtil(List<Corte> cortesABuscarUltimoUtil, string terminal)
        {
            //Si no quedan cortes, que devuelva la lista como estaba
            if (listaCortes.Count == 0) { return cortesABuscarUltimoUtil; }
            //Si ya tengo dicho cual dejar ultimo
            if (terminal != "")
            {
                List<Corte> listaAcomodada = new List<Corte>();
                List<Corte> listaUltimosCortes = new List<Corte>();
                for (int j = 0; j < cortesABuscarUltimoUtil.Count; j++)
                {
                    if (cortesABuscarUltimoUtil[j].terminal2 == terminal)
                    {
                        listaUltimosCortes.Add(cortesABuscarUltimoUtil[j]);
                    }
                    else
                    {
                        listaAcomodada.Add(cortesABuscarUltimoUtil[j]);
                    }
                }
                for (int j = 0; j < listaUltimosCortes.Count; j++)
                {
                    listaAcomodada.Add(listaUltimosCortes[j]);
                }
                return listaAcomodada;
            }
            //Si no tiene dicho, que lo busque
            else
            {
                //Si si quedan cortes, que recorra la lista hasta encontrar un terminal que no se haya usado
                for (int i = 0; i < cortesABuscarUltimoUtil.Count; i++)
                {
                    //Si encuentra uno, que deje todos los cortes con ese temrinal para lo ultimo
                    if (HayCorteConEsteTerminal(cortesABuscarUltimoUtil[i].terminal2, listaCortes))
                    {
                        List<Corte> listaAcomodada = new List<Corte>();
                        List<Corte> listaUltimosCortes = new List<Corte>();
                        for (int j = 0; j < cortesABuscarUltimoUtil.Count; j++)
                        {
                            if (cortesABuscarUltimoUtil[j].terminal2 == cortesABuscarUltimoUtil[i].terminal2)
                            {
                                listaUltimosCortes.Add(cortesABuscarUltimoUtil[j]);
                            }
                            else
                            {
                                listaAcomodada.Add(cortesABuscarUltimoUtil[j]);
                            }
                        }
                        for (int j = 0; j < listaUltimosCortes.Count; j++)
                        {
                            listaAcomodada.Add(listaUltimosCortes[j]);
                        }
                        return listaAcomodada;
                    }
                }

            }
            //Si llega a este punto, es porque no tiene ningun terminal que no se haya usado aun, devuelve la lista como vino
            return cortesABuscarUltimoUtil;
        }

        public static void AgregarCortesALista(List<Corte> listaALaQueAgrego, List<Corte> listaQueAgrego)
        {
            listaALaQueAgrego.AddRange(listaQueAgrego);
        }

        public static bool soloLeQuedanCortesConEseSoloTerminal(string terminal , List<Corte> listaEnLaQueBusco)
        {
            for (int i = 0; i < listaEnLaQueBusco.Count; i++)
            {
                if ( (listaEnLaQueBusco[i].terminal1 == terminal & listaEnLaQueBusco[i].terminal2 != "") | (listaEnLaQueBusco[i].terminal1 != "" & listaEnLaQueBusco[i].terminal2 == terminal)) { return false; }
            }
            return true;
        }

        public static List<Corte> ObtenerCortesConEsteTerminal(string terminal, List<Corte> deEstaLista)
        {
            List<Corte> cortesConEsteTerminal = new List<Corte>();
            for (int i = 0; i < deEstaLista.Count; i++)
            {
                if (deEstaLista[i].terminal1 == terminal)
                {
                    cortesConEsteTerminal.Add(deEstaLista[i]);
                    deEstaLista[i] = null;
                }
                else if (deEstaLista[i].terminal2 == terminal)
                {
                    DarVueltaTerminales(i, deEstaLista);
                    cortesConEsteTerminal.Add(deEstaLista[i]);
                    deEstaLista[i] = null;
                }
            }
            QuitarNullsDeLista(deEstaLista);
            return cortesConEsteTerminal;
        }

        public static void QuitarNullsDeLista(List<Corte> cortesAAcomodar)
        {
            cortesAAcomodar.RemoveAll(x => x == null);
        }

        public static bool HayCorteConEsteTerminal(string terminal, List<Corte> listaDondeBusco)
        {
            for (int i = 0; i < listaDondeBusco.Count; i++)
            {
                if (listaDondeBusco[i].terminal1 == terminal | listaDondeBusco[i].terminal2 == terminal) { return true; }
            }
            return false;
        }

        public static void GrabarDatos()
        {
            List<Object> LCAM_LCD_R = new List<object>();
            LCAM_LCD_R.Add(listaCortesAMostrar);
            LCAM_LCD_R.Add(cortesDescartadosAmostrar);
            LCAM_LCD_R.Add(numerosDeOrden);
            LCAM_LCD_R.Add(rutas);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsout = new FileStream("C:\\Gestor Cortes\\Binarios\\" + nombreProceso + ".binary", FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                using (fsout)
                {
                    bf.Serialize(fsout, LCAM_LCD_R);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos en el archivo binario. Descripción del error: " + ex.Message);
            }
        }

        public static void LeerDatos()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsin = new FileStream("C:\\Gestor Cortes\\Binarios\\" + nombreProceso + ".binary", FileMode.Open, FileAccess.Read, FileShare.None);
            try
            {
                using (fsin)
                {
                    List<Object> LCAM_LCD_R = (List<Object>)bf.Deserialize(fsin);
                    listaCortesAMostrar = (List<Corte>)LCAM_LCD_R[0];
                    cortesDescartadosAmostrar = (List<Corte>)LCAM_LCD_R[1];
                    numerosDeOrden = (List<int>)LCAM_LCD_R[2];
                    rutas = (List<string>)LCAM_LCD_R[3];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer los datos del archivo binario. Descripción del error: " + ex.Message);
            }
        }

        public static void LeerNombreUltimoProceso()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsin = new FileStream("C:\\Gestor Cortes\\Binarios\\IUP\\iup.binary", FileMode.Open, FileAccess.Read, FileShare.None);
            try
            {
                using (fsin)
                {
                    nombreProceso = (string)bf.Deserialize(fsin);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el nombre del último proceso del archivo binario. Descripción del error: " + ex.Message);
            }
        }

        public static int ObtenerIndiceCortesPorProcesar()
        {
            if (listaCortesAMostrar[0] == null) { return 0; }
            for (int i = 0; i < listaCortesAMostrar.Count; i++)
            {
                if (listaCortesAMostrar[i].estado == "")
                {
                    return i;
                }
            }
            return -1;
        }

        public static int ObtenerIndiceCortesPorProcesar(List<Corte> listaEnDondeSeBuscaElCorte)
        {
            for (int i = 0; i < listaEnDondeSeBuscaElCorte.Count; i++)
            {
                if (listaEnDondeSeBuscaElCorte[i].estado == "")
                {
                    return i;
                }
            }
            return -1;
        }

        //Devuelve el indice donde se tiene que seleccionar al cargar (si estan todos terminados los cortes devuelve el indice del utimo)
        public static int buscarIndiceAlCargar()
        {
            int indice = ObtenerIndiceCortesPorProcesar();
            if (indice == -1) { return listaCortesAMostrar.Count - 1; }
            return indice;
        }

        public static List<string> obtenerUltimosTerminales(int indicePrimerSinEstado, List<Corte> listaAMostrar)
        {
            List<string> terminales = new List<string>();
            string terminal1 = "";
            string terminal2 = "";
            for (int i = indicePrimerSinEstado - 1; i > -1; i--)
            {
                if (terminal1 == "")
                {
                    if (listaAMostrar[i].terminal1 != "")
                    {
                        terminal1 = listaAMostrar[i].terminal1;
                        if (terminal2 != "")
                        {
                            terminales.Add(terminal1);
                            terminales.Add(terminal2);
                            return terminales;
                        }
                    }
                }
                if (terminal2 == "")
                {
                    if (listaAMostrar[i].terminal2 != "")
                    {
                        terminal2 = listaAMostrar[i].terminal2;
                        if (terminal1 != "")
                        {
                            terminales.Add(terminal1);
                            terminales.Add(terminal2);
                            return terminales;
                        }
                    }
                }
            }
            terminales.Add(terminal1);
            terminales.Add(terminal2);
            return terminales;
        }

        public static void ordenarPorSeccionDesdeIndice(int indice)
        {
            List<Corte> yaOrdenados = new List<Corte>();
            List<Corte> aOrdenar = new List<Corte>();
            string terminal1 = listaCortesAMostrar[indice].terminal1;
            string terminal2 = listaCortesAMostrar[indice].terminal2;
            aOrdenar.Add(listaCortesAMostrar[indice]);
            for (int i = indice + 1; i < listaCortesAMostrar.Count; i++)
            {
                if (listaCortesAMostrar[i].terminal1 == terminal1 & listaCortesAMostrar[i].terminal2 == terminal2)
                { aOrdenar.Add(listaCortesAMostrar[i]); }
                else
                {
                    aOrdenar = OrdenarCortesPorSeccion(aOrdenar);
                    AgregarCortesALista(yaOrdenados, aOrdenar);
                    aOrdenar.Clear();
                    terminal1 = listaCortesAMostrar[i].terminal1;
                    terminal2 = listaCortesAMostrar[i].terminal2;
                    aOrdenar.Add(listaCortesAMostrar[i]);
                }
            }
            aOrdenar = OrdenarCortesPorSeccion(aOrdenar);
            AgregarCortesALista(yaOrdenados, aOrdenar);
            for (int i = 0; i < yaOrdenados.Count; i++)
            {
                listaCortesAMostrar[indice + i] = yaOrdenados[i];
            }
        }

        public static List<Corte> ordenarPorSeccionDesdeIndice(int indice, List<Corte> listaAOrdenar)
        {
            if (listaAOrdenar.Count == 0) { return listaAOrdenar; }
            List<Corte> yaOrdenados = new List<Corte>();
            List<Corte> aOrdenar = new List<Corte>();
            string terminal1 = listaAOrdenar[indice].terminal1;
            string terminal2 = listaAOrdenar[indice].terminal2;
            aOrdenar.Add(listaAOrdenar[indice]);
            for (int i = indice + 1; i < listaAOrdenar.Count; i++)
            {
                if (listaAOrdenar[i].terminal1 == terminal1 & listaAOrdenar[i].terminal2 == terminal2)
                { aOrdenar.Add(listaAOrdenar[i]); }
                else
                {
                    aOrdenar = OrdenarCortesPorSeccion(aOrdenar);
                    AgregarCortesALista(yaOrdenados, aOrdenar);
                    aOrdenar.Clear();
                    terminal1 = listaAOrdenar[i].terminal1;
                    terminal2 = listaAOrdenar[i].terminal2;
                    aOrdenar.Add(listaAOrdenar[i]);
                }
            }
            aOrdenar = OrdenarCortesPorSeccion(aOrdenar);
            AgregarCortesALista(yaOrdenados, aOrdenar);
            return yaOrdenados;
        }

        public static void ordenarPorColorDesdeIndice(int indice)
        {
            List<Corte> yaOrdenados = new List<Corte>();
            List<Corte> aOrdenar = new List<Corte>();
            string terminal1 = listaCortesAMostrar[indice].terminal1;
            string terminal2 = listaCortesAMostrar[indice].terminal2;
            string seccion = listaCortesAMostrar[indice].seccion;
            aOrdenar.Add(listaCortesAMostrar[indice]);
            for (int i = indice + 1; i < listaCortesAMostrar.Count; i++)
            {
                if (listaCortesAMostrar[i].terminal1 == terminal1 & listaCortesAMostrar[i].terminal2 == terminal2 & listaCortesAMostrar[i].seccion == seccion)
                { aOrdenar.Add(listaCortesAMostrar[i]); }
                else
                {
                    aOrdenar = OrdenarCortesPorColor(aOrdenar);
                    AgregarCortesALista(yaOrdenados, aOrdenar);
                    aOrdenar.Clear();
                    terminal1 = listaCortesAMostrar[i].terminal1;
                    terminal2 = listaCortesAMostrar[i].terminal2;
                    seccion = listaCortesAMostrar[i].seccion;
                    aOrdenar.Add(listaCortesAMostrar[i]);
                }
            }
            aOrdenar = OrdenarCortesPorColor(aOrdenar);
            AgregarCortesALista(yaOrdenados, aOrdenar);
            for (int i = 0; i < yaOrdenados.Count; i++)
            {
                listaCortesAMostrar[indice + i] = yaOrdenados[i];
            }
        }

        //De una lista, de un conjunto de cortes que tengan el mismo temrinal 1 y 2, y misma seccion, los acomoda por color
        public static List<Corte> ordenarPorColorDesdeIndice(int indice, List<Corte> listaAOrdenar)
        {
            if (listaAOrdenar.Count == 0) { return listaAOrdenar; }
            List<Corte> yaOrdenados = new List<Corte>();
            List<Corte> aOrdenar = new List<Corte>();
            string terminal1 = listaAOrdenar[indice].terminal1;
            string terminal2 = listaAOrdenar[indice].terminal2;
            string seccion = listaAOrdenar[indice].seccion;
            aOrdenar.Add(listaAOrdenar[indice]);
            listaAOrdenar[indice] = null;
            for (int i = indice + 1; i < listaAOrdenar.Count; i++)
            {
                if (listaAOrdenar[i] != null)
                {
                    if (listaAOrdenar[i].terminal1 == terminal1 & listaAOrdenar[i].terminal2 == terminal2 & listaAOrdenar[i].seccion == seccion)
                    { aOrdenar.Add(listaAOrdenar[i]); listaAOrdenar[i] = null; }
                    else
                    {
                        aOrdenar = OrdenarCortesPorColor(aOrdenar);
                        AgregarCortesALista(yaOrdenados, aOrdenar);
                        aOrdenar.Clear();
                        terminal1 = listaAOrdenar[i].terminal1;
                        terminal2 = listaAOrdenar[i].terminal2;
                        seccion = listaAOrdenar[i].seccion;
                        aOrdenar.Add(listaAOrdenar[i]);
                        listaAOrdenar[i] = null;
                    }
                }
            }
            aOrdenar = OrdenarCortesPorColor(aOrdenar);
            AgregarCortesALista(yaOrdenados, aOrdenar);
            return yaOrdenados;
        }

        //Ordena los cortes en listaCortesAMstrar de manera descendente
        public static void ordenarPorLongitudDesdeIndice(int indice)
        {
            List<Corte> yaOrdenados = new List<Corte>();
            List<Corte> aOrdenar = new List<Corte>();
            string terminal1 = listaCortesAMostrar[indice].terminal1;
            string terminal2 = listaCortesAMostrar[indice].terminal2;
            string seccion = listaCortesAMostrar[indice].seccion;
            string color = listaCortesAMostrar[indice].color;
            aOrdenar.Add(listaCortesAMostrar[indice]);
            for (int i = indice + 1; i < listaCortesAMostrar.Count; i++)
            {
                if (listaCortesAMostrar[i].terminal1 == terminal1 & listaCortesAMostrar[i].terminal2 == terminal2 & listaCortesAMostrar[i].seccion == seccion & listaCortesAMostrar[i].color == color)
                { aOrdenar.Add(listaCortesAMostrar[i]); }
                else
                {
                    aOrdenar = OrdenarCortesPorLongitud(aOrdenar);
                    AgregarCortesALista(yaOrdenados, aOrdenar);
                    aOrdenar.Clear();
                    terminal1 = listaCortesAMostrar[i].terminal1;
                    terminal2 = listaCortesAMostrar[i].terminal2;
                    seccion = listaCortesAMostrar[i].seccion;
                    color = listaCortesAMostrar[i].color;
                    aOrdenar.Add(listaCortesAMostrar[i]);
                }
            }
            aOrdenar = OrdenarCortesPorLongitud(aOrdenar);
            AgregarCortesALista(yaOrdenados, aOrdenar);
            for (int i = 0; i < yaOrdenados.Count; i++)
            {
                listaCortesAMostrar[indice + i] = yaOrdenados[i];
            }
        }

        //Orden a los cortes que son iguales (mismo color, seccion y cabezales) por longitud descendente en toda la lista, y devuelvo la lista acomodada
        public static List<Corte> ordenarPorLongitudDesdeIndice(List<Corte> listaAOrdenar)
        {
            if (listaAOrdenar.Count == 0) { return listaAOrdenar; }
            List<Corte> yaOrdenados = new List<Corte>();
            List<Corte> aOrdenar = new List<Corte>();
            string terminal1 = listaAOrdenar[0].terminal1;
            string terminal2 = listaAOrdenar[0].terminal2;
            string seccion = listaAOrdenar[0].seccion;
            string color = listaAOrdenar[0].color;
            aOrdenar.Add(listaAOrdenar[0]);
            listaAOrdenar[0] = null;
            for (int i = 1; i < listaAOrdenar.Count; i++)
            {
                if (listaAOrdenar[i] != null)
                {
                    if (listaAOrdenar[i].terminal1 == terminal1 & listaAOrdenar[i].terminal2 == terminal2 & listaAOrdenar[i].seccion == seccion & listaAOrdenar[i].color == color)
                    { aOrdenar.Add(listaAOrdenar[i]); listaAOrdenar[i] = null; }
                    else
                    {
                        aOrdenar = OrdenarCortesPorLongitud(aOrdenar);
                        AgregarCortesALista(yaOrdenados, aOrdenar);
                        aOrdenar.Clear();
                        terminal1 = listaAOrdenar[i].terminal1;
                        terminal2 = listaAOrdenar[i].terminal2;
                        seccion = listaAOrdenar[i].seccion;
                        color = listaAOrdenar[i].color;
                        aOrdenar.Add(listaAOrdenar[i]);
                        listaAOrdenar[i] = null;
                    }
                }
            }
            aOrdenar = OrdenarCortesPorLongitud(aOrdenar);
            AgregarCortesALista(yaOrdenados, aOrdenar);
            return yaOrdenados;
        }

        //Orden a los cortes que son iguales (mismo color, seccion y cabezales) por longitud ascendiente a partir de un indice, y devuelvo la lista cmpleta
        public static List<Corte> ordenarPorLongitudDesdeIndice(int indice, List<Corte> listaAOrdenar)
        {
            if (listaAOrdenar.Count == 0) { return listaAOrdenar; }
            List<Corte> yaOrdenados = new List<Corte>();
            List<Corte> aOrdenar = new List<Corte>();
            string terminal1 = listaAOrdenar[indice].terminal1;
            string terminal2 = listaAOrdenar[indice].terminal2;
            string seccion = listaAOrdenar[indice].seccion;
            string color = listaAOrdenar[indice].color;
            aOrdenar.Add(listaAOrdenar[indice]);
            listaAOrdenar[indice] = null;
            for (int i = indice + 1; i < listaAOrdenar.Count; i++)
            {
                if (listaAOrdenar[i] != null)
                {
                    if (listaAOrdenar[i].terminal1 == terminal1 & listaAOrdenar[i].terminal2 == terminal2 & listaAOrdenar[i].seccion == seccion & listaAOrdenar[i].color == color)
                    { aOrdenar.Add(listaAOrdenar[i]); listaAOrdenar[i] = null; }
                    else
                    {
                        aOrdenar = OrdenarCortesPorLongitud(aOrdenar);
                        AgregarCortesALista(yaOrdenados, aOrdenar);
                        aOrdenar.Clear();
                        terminal1 = listaAOrdenar[i].terminal1;
                        terminal2 = listaAOrdenar[i].terminal2;
                        seccion = listaAOrdenar[i].seccion;
                        color = listaAOrdenar[i].color;
                        aOrdenar.Add(listaAOrdenar[i]);
                        listaAOrdenar[i] = null;
                    }
                }
            }
            aOrdenar = OrdenarCortesPorLongitud(aOrdenar);
            AgregarCortesALista(yaOrdenados, aOrdenar);
            QuitarNullsDeLista(listaAOrdenar);
            AgregarCortesALista(listaAOrdenar, yaOrdenados);
            return listaAOrdenar;
        }

        public static int hayAlgunCorteConEstosDosTerminales(string terminal1, string terminal2, List<Corte> listaDondeBusco)
        {
            for (int i = 0; i < listaDondeBusco.Count; i++)
            {
                if ( (listaDondeBusco[i].terminal1 == terminal1 & listaDondeBusco[i].terminal2 == terminal2) | (listaDondeBusco[i].terminal2 == terminal1 & listaDondeBusco[i].terminal1 == terminal2) ) { return i; }
            }
            return -1;
        }

        public static List<Corte> obtenerCortesConEstasTerminalesYEliminarlosDeListaCortes(string terminal1, string terminal2, List<Corte> listaABuscarLosCortes, int indice, int indicePrimeroSinEstado)
        {
            List<Corte> cortesConEsasTerminales = new List<Corte>();
            for (int i = indice; i < listaABuscarLosCortes.Count; i++)
            {
                if ((listaABuscarLosCortes[i].terminal1 == terminal1 & listaABuscarLosCortes[i].terminal2 == terminal2) | (listaABuscarLosCortes[i].terminal2 == terminal1 & listaABuscarLosCortes[i].terminal1 == terminal2))
                {
                    if (listaABuscarLosCortes[i].color == listaCortesAMostrar[indicePrimeroSinEstado].color & listaABuscarLosCortes[i].seccion == listaCortesAMostrar[indicePrimeroSinEstado].seccion)
                    {
                        listaCortesAMostrar.Add(listaABuscarLosCortes[i]);
                        listaABuscarLosCortes[i] = null;
                    }
                    else
                    {
                        cortesConEsasTerminales.Add(listaABuscarLosCortes[i]);
                        listaABuscarLosCortes[i] = null;
                    }
                }
            }
            QuitarNullsDeLista(listaABuscarLosCortes);
            if (cortesConEsasTerminales.Count != 0)
            {
                cortesConEsasTerminales = ordenarPorSeccionDesdeIndice(0, cortesConEsasTerminales);
                cortesConEsasTerminales = ordenarPorColorDesdeIndice(0, cortesConEsasTerminales);
            }
            return cortesConEsasTerminales;
        }

        public static List<Corte> acomodarLosCortesSinTerminal(List<Corte> listaEnDondeSeAgregan, List<Corte> cortesSinTerminal)
        {
            //Recorro todos los cortes con terminales (que tengan una o dos) que ya estan acomodados
            int acum = 0;
            for (int i = 0; i < listaEnDondeSeAgregan.Count; i++)
            {
                //Si el proximo corte (con temrinal/es) usa el mismo cable y la misma longitud, pasa al siguiente (asi se agrega el corte sin terminales despues de todos los que son iguales)
                if (i < listaEnDondeSeAgregan.Count - 1)
                {
                    if (listaEnDondeSeAgregan[i + 1].terminal1 == listaEnDondeSeAgregan[i].terminal1 &
                        listaEnDondeSeAgregan[i + 1].terminal2 == listaEnDondeSeAgregan[i].terminal2 &
                        listaEnDondeSeAgregan[i + 1].seccion == listaEnDondeSeAgregan[i].seccion &
                        listaEnDondeSeAgregan[i + 1].color == listaEnDondeSeAgregan[i].color) { continue; }
                }
                acum = 0;
                //Cuando encuentro un corte que no es igual al proximo, me fijo si hay algun corte sin remrinales que aproveche el mismo cable (color y seccion), y lo inserto
                for (int j = 0; j < cortesSinTerminal.Count; j++)
                {
                    if (cortesSinTerminal[j] != null)
                    {
                        if (cortesSinTerminal[j].color == listaEnDondeSeAgregan[i].color & cortesSinTerminal[j].seccion == listaEnDondeSeAgregan[i].seccion)
                        {
                            listaEnDondeSeAgregan.Insert(i + 1 + acum, cortesSinTerminal[j]);
                            acum++;
                            cortesSinTerminal[j] = null;
                        }
                    }
                }
                i += acum;
            }
            cortesSinTerminal.RemoveAll(x => x == null);
            if (cortesSinTerminal.Count != 0)
            {
                cortesSinTerminal = OrdenarCortesPorSeccion(cortesSinTerminal);
                cortesSinTerminal = ordenarPorColorDesdeIndice(0, cortesSinTerminal);
                acomodarCortesSinTerminalDondeHayaSeccionIgual(cortesSinTerminal, listaEnDondeSeAgregan);
            }
            return listaEnDondeSeAgregan;
        }

        //Al agregar
        public static void acomodarLosCortesSinTerminal(List<Corte> cortesSinTerminal, int indicePrimerSinEstado, List<Corte> listaAMostrar)
        {
            //Me fijo si hay algun corte sin terminal que usa el mismo cable que el ultimo corte, y lo agrego inmediatamente despues del ultimo corte
            for (int i = 0; i < cortesSinTerminal.Count; i++)
            {
                if (cortesSinTerminal[i].color == listaAMostrar[indicePrimerSinEstado].color & cortesSinTerminal[i].seccion == listaAMostrar[indicePrimerSinEstado].seccion)
                {
                    listaAMostrar.Insert(indicePrimerSinEstado + 1, cortesSinTerminal[i]);
                    cortesSinTerminal[i] = null;
                }
            }
            QuitarNullsDeLista(cortesSinTerminal);

            int acum = 0;
            for (int i = indicePrimerSinEstado; i < listaAMostrar.Count; i++)
            {
                //Si el proximo corte usa el mismo cable y la misma longitud, pasa al siguiente (asi se agrega el corte sin terminales despues de todos los que son iguales)
                if (i < listaAMostrar.Count - 1)
                {
                    if (listaAMostrar[i + 1].terminal1 == listaAMostrar[i].terminal1 &
                        listaAMostrar[i + 1].terminal2 == listaAMostrar[i].terminal2 &
                        listaAMostrar[i + 1].seccion == listaAMostrar[i].seccion &
                        listaAMostrar[i + 1].color == listaAMostrar[i].color) { continue; }
                }
                acum = 0;
                for (int j = 0; j < cortesSinTerminal.Count; j++)
                {
                    if (cortesSinTerminal[j] != null)
                    {
                        if (cortesSinTerminal[j].color == listaAMostrar[i].color & cortesSinTerminal[j].seccion == listaAMostrar[i].seccion)
                        {
                            listaAMostrar.Insert(i + 1 + acum, cortesSinTerminal[j]);
                            acum++;
                            cortesSinTerminal[j] = null;
                        }
                    }
                }
                i += acum;
            }
            cortesSinTerminal.RemoveAll(x => x == null);
            if (cortesSinTerminal.Count != 0)
            {
                cortesSinTerminal = OrdenarCortesPorSeccion(cortesSinTerminal);
                cortesSinTerminal = ordenarPorColorDesdeIndice(0, cortesSinTerminal);
                acomodarCortesSinTerminalDondeHayaSeccionIgual(cortesSinTerminal, listaAMostrar, indicePrimerSinEstado);
            }
        }

        public static List<Corte> acomodarLosCortesDeUnSoloTerminal(List<Corte> listaEnDondeSeAgregan, List<Corte> cortesDeUnSoloTerminal)
        {
            //Primero los acomodo por seccion y color y longitud
            cortesDeUnSoloTerminal = OrdenarCortesPorTerminal1(cortesDeUnSoloTerminal);
            cortesDeUnSoloTerminal = ordenarPorSeccionDesdeIndice(0,cortesDeUnSoloTerminal);
            cortesDeUnSoloTerminal = ordenarPorColorDesdeIndice(0, cortesDeUnSoloTerminal);
            //Primero recorre todos los corte a ver si tenes un corte con un solo terminal que use el mismo cable que uno de dos terminales que contenga el terminal dicho
            //En ese caso, agrego el corte d eun solo terminal despues del ultimo corte de dos terminales que tenga el mismo cable
            int acum = 0;
            string term1 = "";
            string term2 = "";
            string color = "";
            string seccion = "";
            for (int i = 0; i < listaEnDondeSeAgregan.Count; i++)
            {
                acum = 0;
                //Si el corte actual no coincide con el anterior (o es el primero), guardo sus datos en las variables
                if (term1 != listaEnDondeSeAgregan[i].terminal1 |
                    term2 != listaEnDondeSeAgregan[i].terminal2 |
                    seccion != listaEnDondeSeAgregan[i].seccion |
                    color != listaEnDondeSeAgregan[i].color)
                {
                    term1 = listaEnDondeSeAgregan[i].terminal1;
                    term2 = listaEnDondeSeAgregan[i].terminal2;
                    color = listaEnDondeSeAgregan[i].color;
                    seccion = listaEnDondeSeAgregan[i].seccion;
                }
                //Si no es el ultimo, me fijo si el que le sigue es igual (en ese caso, aumento una iteracion del if)
                //Asi, solamente veo si pongo el corte de un terminal despues del ultimo corte de dos temrinales que use su cable
                if (i < listaEnDondeSeAgregan.Count - 1)
                {
                    if (listaEnDondeSeAgregan[i + 1].terminal1 == term1 &
                        listaEnDondeSeAgregan[i + 1].terminal2 == term2 &
                        listaEnDondeSeAgregan[i + 1].seccion == seccion &
                        listaEnDondeSeAgregan[i + 1].color == color) { continue; }
                }
                //Despues recorro todos los de un terminal, y los que compartan el cable, los agrego en esta posicion (despues del ultimo de dos temrinales con ese cable)
                for (int j = 0; j < cortesDeUnSoloTerminal.Count; j++)
                {
                    if (cortesDeUnSoloTerminal[j] != null)
                    {
                        if ((listaEnDondeSeAgregan[i].terminal1 == cortesDeUnSoloTerminal[j].terminal1 | listaEnDondeSeAgregan[i].terminal2 == cortesDeUnSoloTerminal[j].terminal1) &
                            (listaEnDondeSeAgregan[i].color == cortesDeUnSoloTerminal[j].color & listaEnDondeSeAgregan[i].seccion == cortesDeUnSoloTerminal[j].seccion))
                        {
                            listaEnDondeSeAgregan.Insert(i + 1 + acum, cortesDeUnSoloTerminal[j]);
                            acum++;
                            cortesDeUnSoloTerminal[j] = null;
                        }
                    }
                }
                i += acum;
            }
            acum = 0;
            int indiceUltimo = -1;
            QuitarNullsDeLista(cortesDeUnSoloTerminal);

            //En esa lista van a ir los cortes que tienen un terminal que no aparece en ningun corte de dos terminales
            List<Corte> cortesALoUltimo = new List<Corte>();
            //En esa lista van a ir los terminales que no aparece en ningun corte de dos terminales
            List<string> terminalesALoUltimo = new List<string>();

            //Despues a los que me quedaron (que no pueden aprovechar ningun cable anterior) los pongo despues de la ultima vez que aparece ese terminal, o si no aparecio nunca ese temrinal antes, al fondo
            //Los pongo de forma que pongo a continuacion aquellos cortes que tengan la misma seccion que la ultima aparicion del terminal
            for (int j = 0; j < cortesDeUnSoloTerminal.Count; j++)
            {
                //Si ya se que esa terminal no aparece en ningun corte de dos temrinales, la mando directo al fondo
                if (terminalesALoUltimo.Contains(cortesDeUnSoloTerminal[j].terminal1))
                {
                    cortesALoUltimo.Add(cortesDeUnSoloTerminal[j]);
                }
                else
                {
                    indiceUltimo = encontrarUltimoIndiceDondeApareceElTerminal(cortesDeUnSoloTerminal[j].terminal1, listaEnDondeSeAgregan, cortesDeUnSoloTerminal[j].seccion);
                    //Si no aparece nunca ese terminal en un corte de dos terminales, lo añado a la lista
                    if (indiceUltimo == -1)
                    {
                        terminalesALoUltimo.Add(cortesDeUnSoloTerminal[j].terminal1);
                        cortesALoUltimo.Add(cortesDeUnSoloTerminal[j]);
                    }
                    else
                    {
                        listaEnDondeSeAgregan.Insert(indiceUltimo + 1, cortesDeUnSoloTerminal[j]);
                    }
                }
            }

            //Si tengo cortes que no puse en ningun lado, los poongo a lo ultimo, comodados
            if (cortesALoUltimo.Count != 0)
            {
                cortesALoUltimo = OrdenarCortesPorTerminal1(cortesALoUltimo);
                cortesALoUltimo = ordenarPorSeccionDesdeIndice(0,cortesALoUltimo);
                cortesALoUltimo = ordenarPorColorDesdeIndice(0,cortesALoUltimo);
            }
            AgregarCortesALista(listaEnDondeSeAgregan, cortesALoUltimo);
            return listaEnDondeSeAgregan;
        }

        //Al agregar
        public static void acomodarLosCortesDeUnSoloTerminal(List<Corte> listaEnDondeSeAgregan, List<Corte> cortesDeUnSoloTerminal, int indicePrimerSinEstado, List<string> ultimosTerminales, List<Corte> listaAMostrar)
        {
            //Me fijo si hay algun corte de un terminal que tenga una de las dos ultimas terminales usa el mismo cable que el ultimo corte, y lo agrego
            for (int i = 0; i < cortesDeUnSoloTerminal.Count; i++)
            {
                if (
                    (cortesDeUnSoloTerminal[i].terminal1 == ultimosTerminales[0] | cortesDeUnSoloTerminal[i].terminal1 == ultimosTerminales[1])
                    &
                    (cortesDeUnSoloTerminal[i].color == listaAMostrar[indicePrimerSinEstado].color & cortesDeUnSoloTerminal[i].seccion == listaAMostrar[indicePrimerSinEstado].seccion)
                    )
                {
                    listaAMostrar.Add(cortesDeUnSoloTerminal[i]);
                    cortesDeUnSoloTerminal[i] = null;
                }
            }
            QuitarNullsDeLista(cortesDeUnSoloTerminal);

            //Primero los acomodo por seccion y color
            cortesDeUnSoloTerminal = OrdenarCortesPorTerminal1(cortesDeUnSoloTerminal);
            cortesDeUnSoloTerminal = ordenarPorSeccionDesdeIndice(0, cortesDeUnSoloTerminal);
            cortesDeUnSoloTerminal = ordenarPorColorDesdeIndice(0, cortesDeUnSoloTerminal);
            //Primero recorre todos los corte a ver si tenes un corte con un solo terminal que use el mismo cable que uno de dos terminales que contenga el terminal dicho
            //En ese caso, agrego el corte d eun solo terminal despues del ultimo corte de dos terminales que tenga el mismo cable
            int acum = 0;
            string term1 = "";
            string term2 = "";
            string color = "";
            string seccion = "";
            for (int i = 0; i < listaEnDondeSeAgregan.Count; i++)
            {
                acum = 0;
                //Si el corte actual no coincide con el anterior (o es el primero), guardo sus datos en las variables
                if (term1 != listaEnDondeSeAgregan[i].terminal1 |
                    term2 != listaEnDondeSeAgregan[i].terminal2 |
                    seccion != listaEnDondeSeAgregan[i].seccion |
                    color != listaEnDondeSeAgregan[i].color)
                {
                    term1 = listaEnDondeSeAgregan[i].terminal1;
                    term2 = listaEnDondeSeAgregan[i].terminal2;
                    color = listaEnDondeSeAgregan[i].color;
                    seccion = listaEnDondeSeAgregan[i].seccion;
                }
                //Si no es el ultimo, me fijo si el que le sigue es igual (en ese caso, aumento una iteracion del if)
                //Asi, solamente veo si pongo el corte de un terminal despues del ultimo corte de dos temrinales que use su cable
                if (i < listaEnDondeSeAgregan.Count - 1)
                {
                    if (listaEnDondeSeAgregan[i + 1].terminal1 == term1 &
                        listaEnDondeSeAgregan[i + 1].terminal2 == term2 &
                        listaEnDondeSeAgregan[i + 1].seccion == seccion &
                        listaEnDondeSeAgregan[i + 1].color == color) { continue; }
                }
                //Despues recorro todos los de un terminal, y los que compartan el cable, los agrego en esta posicion (despues del ultimo de dos temrinales con ese cable)
                for (int j = 0; j < cortesDeUnSoloTerminal.Count; j++)
                {
                    if (cortesDeUnSoloTerminal[j] != null)
                    {
                        if ((listaEnDondeSeAgregan[i].terminal1 == cortesDeUnSoloTerminal[j].terminal1 | listaEnDondeSeAgregan[i].terminal2 == cortesDeUnSoloTerminal[j].terminal1) &
                            (listaEnDondeSeAgregan[i].color == cortesDeUnSoloTerminal[j].color & listaEnDondeSeAgregan[i].seccion == cortesDeUnSoloTerminal[j].seccion))
                        {
                            listaEnDondeSeAgregan.Insert(i + 1 + acum, cortesDeUnSoloTerminal[j]);
                            acum++;
                            cortesDeUnSoloTerminal[j] = null;
                        }
                    }
                }
                i += acum;
            }
            acum = 0;
            int indiceUltimo = -1;
            QuitarNullsDeLista(cortesDeUnSoloTerminal);

            List<Corte> cortesALoUltimo = new List<Corte>();
            List<string> terminalesALoUltimo = new List<string>();

            List<Corte> cortesAPonerAlPrincipio = new List<Corte>();
            List<Corte> UltimoscortesAPonerAlPrincipio = new List<Corte>();

            // De los que me quedan y tienen uno de los dos ultimos terminales pero no sirven en ningun otro cotre, los meto al principio. Si hay alguno que tiene el mismo cable que el primero de dos terminales que voy a meter despues, lo dejo para lo ultimo
            if (listaEnDondeSeAgregan.Count > 0)
            {
                for (int j = 0; j < cortesDeUnSoloTerminal.Count; j++)
                {
                    if (cortesDeUnSoloTerminal[j].terminal1 == ultimosTerminales[0] | cortesDeUnSoloTerminal[j].terminal1 == ultimosTerminales[1])
                    {
                        if (cortesDeUnSoloTerminal[j].seccion == listaEnDondeSeAgregan[0].seccion & cortesDeUnSoloTerminal[j].color == listaEnDondeSeAgregan[0].color)
                        {
                            UltimoscortesAPonerAlPrincipio.Add(cortesDeUnSoloTerminal[j]);
                            cortesDeUnSoloTerminal[j] = null;
                        }
                        else
                        {
                            cortesAPonerAlPrincipio.Add(cortesDeUnSoloTerminal[j]);
                            cortesDeUnSoloTerminal[j] = null;
                        }
                    }
                }
                QuitarNullsDeLista(cortesDeUnSoloTerminal);
            }

            AgregarCortesALista(listaAMostrar, cortesAPonerAlPrincipio);
            AgregarCortesALista(listaAMostrar, UltimoscortesAPonerAlPrincipio);

            //Despues a los que me quedaron (que no pueden aprovechar ningun cable anterior) los pongo despues de la ultima vez que aparece ese terminal, o si no aparecio nunca ese temrinal antes, al fondo
            //Los pongo de forma que pongo a continuacion aquellos cortes que tengan la misma seccion que la ultima aparicion del terminal
            for (int j = 0; j < cortesDeUnSoloTerminal.Count; j++)
            {
                //Si ya se que esa terminal no aparece en ningun corte de dos temrinales, la mando directo al fondo
                if (terminalesALoUltimo.Contains(cortesDeUnSoloTerminal[j].terminal1))
                {
                    cortesALoUltimo.Add(cortesDeUnSoloTerminal[j]);
                }
                else
                {
                    indiceUltimo = encontrarUltimoIndiceDondeApareceElTerminal(cortesDeUnSoloTerminal[j].terminal1, listaEnDondeSeAgregan, cortesDeUnSoloTerminal[j].seccion);
                    //Si no aparece nunca ese terminal en un corte de dos terminales, lo añado a la lista
                    if (indiceUltimo == -1)
                    {
                        terminalesALoUltimo.Add(cortesDeUnSoloTerminal[j].terminal1);
                        cortesALoUltimo.Add(cortesDeUnSoloTerminal[j]);
                    }
                    else
                    {
                        listaEnDondeSeAgregan.Insert(indiceUltimo + 1, cortesDeUnSoloTerminal[j]);
                    }
                }
            }

            if (cortesALoUltimo.Count != 0)
            {
                cortesALoUltimo = OrdenarCortesPorTerminal1(cortesALoUltimo);
                cortesALoUltimo = ordenarPorSeccionDesdeIndice(0, cortesALoUltimo);
                cortesALoUltimo = ordenarPorColorDesdeIndice(0, cortesALoUltimo);
            }
            AgregarCortesALista(listaEnDondeSeAgregan, cortesALoUltimo);
            AgregarCortesALista(listaAMostrar, listaEnDondeSeAgregan);
        }

        public static List<Corte> darVueltaSiCorrespondeDesdeIndice(int indice, List<Corte> listaAAcomodar)
        {
            int ultimoCambiado = 0;
            string terminal1 = "";
            string terminal2 = "";
            for (int i = indice; i < listaAAcomodar.Count; i++)
            {
                //T1 vacio
                if (listaAAcomodar[i].terminal1 == "") { continue; }
                //Ti no vacio
                else
                {   //Hay un T1
                    //No
                    if (terminal1 == "")
                    {
                        terminal1 = listaAAcomodar[i].terminal1;
                        ultimoCambiado = 1;
                        //T2 vacio
                        //Si
                        if (listaAAcomodar[i].terminal2 == "") { continue; }
                        //no
                        else
                        {terminal2 = listaAAcomodar[i].terminal2; ultimoCambiado = 2;}
                    }
                    //si
                    else
                    {   //Es el mismo
                        //si
                        if (listaAAcomodar[i].terminal1 == terminal1)
                        {   //T2 vacio
                            //si
                            if (listaAAcomodar[i].terminal2 == "") { continue; }
                            //no
                            else
                            {   //Hay un T2
                                //No
                                if (terminal2 == "")
                                {   terminal2 = listaAAcomodar[i].terminal2;
                                    ultimoCambiado = 2;}
                                //si
                                else
                                {   //es el mismo
                                    //si
                                    if (listaAAcomodar[i].terminal2 == terminal2) { continue; }
                                    //no
                                    else
                                    {   terminal2 = listaAAcomodar[i].terminal2;
                                        ultimoCambiado = 2;}
                                }
                            }
                        }
                        //no
                        else
                        {   //es = T2
                            //si
                            if (listaAAcomodar[i].terminal1 == terminal2)
                            {   //t2 vacio
                                //si
                                if (listaAAcomodar[i].terminal2 == "")
                                { DarVueltaTerminales(i, listaAAcomodar); continue; }
                                //no
                                else
                                {   //es t1
                                    //si
                                    if (listaAAcomodar[i].terminal2 == terminal1)
                                    { DarVueltaTerminales(i, listaAAcomodar); continue; }
                                    //no
                                    else
                                    {   terminal1 = listaAAcomodar[i].terminal2;
                                        ultimoCambiado = 1;
                                        DarVueltaTerminales(i, listaAAcomodar);
                                        continue;}
                                }
                            }
                            //no
                            else
                            {   //t2 vacio
                                //si
                                if (listaAAcomodar[i].terminal2 == "")
                                {   if (ultimoCambiado == 2)
                                    { terminal1 = listaAAcomodar[i].terminal1; ultimoCambiado = 1;}
                                    else
                                    {   terminal2 = listaAAcomodar[i].terminal1;
                                        DarVueltaTerminales(i, listaAAcomodar);
                                        ultimoCambiado = 2; }
                                }
                                //no
                                else
                                {   //Es t2
                                    //si
                                    if (listaAAcomodar[i].terminal2 == terminal2)
                                    {   terminal1 = listaAAcomodar[i].terminal1; ultimoCambiado = 1;}
                                    //no
                                    else
                                    {   terminal1 = listaAAcomodar[i].terminal1;
                                        terminal2 = listaAAcomodar[i].terminal2;
                                        ultimoCambiado = 2; }
                                }
                            }
                        }
                    }
                }
            }
            return listaAAcomodar;
        }

        //En una lista, busco la última vez que aparece un terminal, y retorno el indice
        //Si en alguna aparicion, ademas se tiene la misma seccion que se recibe por parametro, retorno el indice de la  ultima posicion en que esto ocurre
        public static int encontrarUltimoIndiceDondeApareceElTerminal(string terminal, List<Corte> listaDondeBusco, string seccion)
        {
            int ultimoIndice = -1;
            int ultimoIndiceEsaSeccion = -1;
            for (int i = 0; i < listaDondeBusco.Count; i++)
            {
                //Si este corte tiene el terminal que busco (ya sea en el 1 o el 2), guardo ese indice en el ultimo indice
                if (terminal == listaDondeBusco[i].terminal1 | terminal == listaDondeBusco[i].terminal2)
                {
                    //Si tiene la misma sección, gurdo el inndice en ultimoIndiceEsaSeccion
                    if (listaDondeBusco[i].seccion == seccion) { ultimoIndiceEsaSeccion = i; continue; }
                    //Si no, guardo el indice en ultimoIndice
                    ultimoIndice = i;
                }
            }
            if (ultimoIndiceEsaSeccion != -1) { return ultimoIndiceEsaSeccion; }
            return ultimoIndice;
        }

        public static void descartoOIncluyo(Corte corte)
        {
            double seccion = 0;
            bool esSeccionValida = double.TryParse(corte.seccion, out seccion);
            if (esSeccionValida == true & seccion < 6)
            {
                listaCortes.Add(corte);
            }
            else
            {
                cortesDescartados.Add(corte);
            }
        }

        //Metodo para agregar cortes sin terminal que no aprovecharon ningun cable que ya estaa acomodado, entonces se ponen donde se encuentre un corte que tenga la misma seccion
        //Para cuando se crea un nuevo proceso, no para cuando se agrega
        public static void acomodarCortesSinTerminalDondeHayaSeccionIgual(List<Corte> cortesSinTerminal, List<Corte> listaDondeSeAgregan)
        {
            List<List<Corte>> listaDeCortesPorSeccion = new List<List<Corte>>();
            Dictionary<string, int> seccionesIncluidasEnLaLista = new Dictionary<string, int>();
            //Ubico todos los cortes en una lista con su seccion correspondiente
            for (int i = 0; i < cortesSinTerminal.Count; i++)
            {
                if (seccionesIncluidasEnLaLista.ContainsKey(cortesSinTerminal[i].seccion))
                {
                    listaDeCortesPorSeccion[seccionesIncluidasEnLaLista[cortesSinTerminal[i].seccion]].Add(cortesSinTerminal[i]);
                    cortesSinTerminal[i] = null;
                }
                else
                {
                    seccionesIncluidasEnLaLista.Add(cortesSinTerminal[i].seccion, listaDeCortesPorSeccion.Count);
                    listaDeCortesPorSeccion.Add(new List<Corte>());
                    listaDeCortesPorSeccion[listaDeCortesPorSeccion.Count - 1].Add(cortesSinTerminal[i]);
                    cortesSinTerminal[i] = null;
                }
            }
            QuitarNullsDeLista(cortesSinTerminal);
            //Recorro la lista de cortes en donde se agregan, y por cda seccion nueva que encuentre, me fijo si tengo cortes para ponerle al final
            for (int i = 0; i < listaDondeSeAgregan.Count; i++)
            {
                //Si el corte siguiente tiene la misma seccion, que lo pase (asi se llega al ultimo con esa seccion)
                if (i + 1 < listaDondeSeAgregan.Count)
                {
                    if (listaDondeSeAgregan[i].seccion == listaDondeSeAgregan[i + 1].seccion) { continue; }
                }

                if (seccionesIncluidasEnLaLista.ContainsKey(listaDondeSeAgregan[i].seccion))
                {
                    int acum = 0;
                    //Cuando encuentro un corte que no es igual al proximo, me fijo si hay algun corte sin remrinales que aproveche el mismo cable (color y seccion), y lo inserto
                    for (int j = 0; j < listaDeCortesPorSeccion[seccionesIncluidasEnLaLista[listaDondeSeAgregan[i].seccion]].Count; j++)
                    {
                        listaDondeSeAgregan.Insert(i + 1 + acum, listaDeCortesPorSeccion[seccionesIncluidasEnLaLista[listaDondeSeAgregan[i].seccion]][j]);
                        acum++;
                    }
                    i += acum;
                    listaDeCortesPorSeccion[seccionesIncluidasEnLaLista[listaDondeSeAgregan[i].seccion]] = null;
                    seccionesIncluidasEnLaLista.Remove(listaDondeSeAgregan[i].seccion);
                }
            }
            //Si me quedaron cortes, los agrego como estan en el final de la lista en la que se agregan
            for (int i = 0; i < listaDeCortesPorSeccion.Count; i++)
            {
                if (listaDeCortesPorSeccion[i] != null)
                {
                    AgregarCortesALista(listaDondeSeAgregan, listaDeCortesPorSeccion[i]);
                }
            }
        }

        //Igual al metodo de arriba, pero para cuando se agregar cortes a un proceso
        public static void acomodarCortesSinTerminalDondeHayaSeccionIgual(List<Corte> cortesSinTerminal, List<Corte> listaDondeSeAgregan, int indicePrimerSinEstado)
        {
            List<List<Corte>> listaDeCortesPorSeccion = new List<List<Corte>>();
            Dictionary<string, int> seccionesIncluidasEnLaLista = new Dictionary<string, int>();
            //Ubico todos los cortes en una lista con su seccion correspondiente
            for (int i = 0; i < cortesSinTerminal.Count; i++)
            {
                if (seccionesIncluidasEnLaLista.ContainsKey(cortesSinTerminal[i].seccion))
                {
                    listaDeCortesPorSeccion[seccionesIncluidasEnLaLista[cortesSinTerminal[i].seccion]].Add(cortesSinTerminal[i]);
                    cortesSinTerminal[i] = null;
                }
                else
                {
                    seccionesIncluidasEnLaLista.Add(cortesSinTerminal[i].seccion, listaDeCortesPorSeccion.Count);
                    listaDeCortesPorSeccion.Add(new List<Corte>());
                    listaDeCortesPorSeccion[listaDeCortesPorSeccion.Count - 1].Add(cortesSinTerminal[i]);
                    cortesSinTerminal[i] = null;
                }
            }
            QuitarNullsDeLista(cortesSinTerminal);

            //Recorro la lista de cortes en donde se agregan, y por cda seccion nueva que encuentre, me fijo si tengo cortes para ponerle al final
            for (int i = indicePrimerSinEstado; i < listaDondeSeAgregan.Count; i++)
            {
                //Si el corte siguiente tiene la misma seccion, que lo pase (asi se llega al ultimo con esa seccion)
                if (i + 1 < listaDondeSeAgregan.Count)
                {
                    if (listaDondeSeAgregan[i].seccion == listaDondeSeAgregan[i + 1].seccion) { continue; }
                }

                if (seccionesIncluidasEnLaLista.ContainsKey(listaDondeSeAgregan[i].seccion))
                {
                    int acum = 0;
                    //Cuando encuentro un corte que no es igual al proximo, me fijo si hay algun corte sin remrinales que aproveche el mismo cable (color y seccion), y lo inserto
                    for (int j = 0; j < listaDeCortesPorSeccion[seccionesIncluidasEnLaLista[listaDondeSeAgregan[i].seccion]].Count; j++)
                    {
                        listaDondeSeAgregan.Insert(i + 1 + acum, listaDeCortesPorSeccion[seccionesIncluidasEnLaLista[listaDondeSeAgregan[i].seccion]][j]);
                        acum++;
                    }
                    i += acum;
                    listaDeCortesPorSeccion[seccionesIncluidasEnLaLista[listaDondeSeAgregan[i].seccion]] = null;
                    seccionesIncluidasEnLaLista.Remove(listaDondeSeAgregan[i].seccion);
                }
            }
            //Si me quedaron cortes, los agrego como estan en el final de la lista en la que se agregan
            for (int i = 0; i < listaDeCortesPorSeccion.Count; i++)
            {
                if (listaDeCortesPorSeccion[i] != null)
                {
                    AgregarCortesALista(listaDondeSeAgregan, listaDeCortesPorSeccion[i]);
                }
            }
        }

        public static void ponerTamañoMinimoColumnas(DataGridView dgv)
        {
            int tamanoColumnasDelDGV = 0;
            double radioDeExpansion = 0;
            
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //Col. NO y NC
                if (i == 0 | i == 1) { if (dgv.Columns[i].Width < 25) { dgv.Columns[i].Width = 25; } }
                //Col du1 du2 dt1 dt2 y observacion
                if (i == 15) { if (dgv.Columns[i].Width < 40) { dgv.Columns[i].Width = 40; } }
                //Col cantidad y longitud
                if (i == 2 | i == 4) { if (dgv.Columns[i].Width < 45) { dgv.Columns[i].Width = 45; } }
                //Col desgarrado
                if (i == 10 | i == 5) { if (dgv.Columns[i].Width < 50) { dgv.Columns[i].Width = 50; } }
                //Col empresa
                if (i == 16) { if (dgv.Columns[i].Width < 70) { dgv.Columns[i].Width = 70; } }
            }
            foreach (DataGridViewColumn columna in dgv.Columns)
            {
                tamanoColumnasDelDGV += columna.Width;
            }
            if (tamanoColumnasDelDGV < dgv.Width)
            {
                radioDeExpansion = (double)dgv.Width / (double)tamanoColumnasDelDGV;
                foreach (DataGridViewColumn columna in dgv.Columns)
                {
                    columna.Width = (int)Math.Truncate(columna.Width * radioDeExpansion);
                }
            }
        }
    }
}
