using System;
using System.Collections.Generic;
using System.Text;

namespace Linear_Regresion
{
    public class LinearRegresion
    {
        //1.-Proyecto Xamarin
        //2.- Hacer el diseño de la pantalla 
            //2.1.- Buscar libreria de graficacion 
        //3.- Agregar libreria
        //4.- Evaluar libreria

        /// <summary>
        /// Metodo que hace el calculo de la regresion lineal
        /// </summary>
        /// <param name="vX">Valores de X</param>
        /// <param name="vY">Valores de Y generalmente evaluados en X</param>
        /// <returns>Lista de dobles con valores de ecuacion de recta a, b, fx</returns>
        public List<double> CalculateLinearRegresion(List<double> vX, List<double> vY, double expectedValue)
        {
            //(22000, 40000)
            List<double> smVal =  SumValues(vX, vY);

            List<double> prom = Promedios(vX, vY, smVal[0], smVal[1]);

            double a = (smVal[1] - (prom[4] * prom[0] * prom[1])) / (smVal[0] - (prom[4] * prom[0] * prom[0]));
            double b = prom[1] - (a * prom[0]);

            double fx = a * expectedValue + b;

            //a = (Sxy - (n * Px * Py)) / (Sxx - (n * Px * Px));
            //b = Py - (a * Px);

            //fx = ax +b
            List<double> vs = new List<double>()
            {
                a,
                b,
                fx
            };

            return vs;
        }

        /// <summary>
        /// Metodo que realiza las sumatorias de los valores de X y de Y
        /// </summary>
        /// <param name="vX">Valores de X</param>
        /// <param name="vY">Valores de Y generalmente evaluados en X</param>
        /// <returns>Lista de doubles con valores de sumatorias de X y Y</returns>
        private List<double> SumValues(List<double> vX, List<double> vY)
        {
            double sumXY = 0.0;
            double sumXX = 0.0;
            List<double> ResultadosSum = new List<double>();

            foreach (var iX in vX)
            {
                sumXX += (iX * iX);
                foreach (var iY in vY)
                {
                    //(3,5,6,7,3) (5,6,8,1,4)
                    sumXY += (iX * iY);
                }
            }

            ResultadosSum.Add(sumXX);
            ResultadosSum.Add(sumXY);
            return ResultadosSum;
        }
        /// <summary>
        /// Metodo que realiza los promedios de cada lista de valores
        /// </summary>
        /// <param name="vX">Valores de X</param>
        /// <param name="vY">Valores de Y generalmente evaluados en X</param>
        /// <param name="sumXy">Sumatoria de Y</param>
        /// <param name="sumXx">Sumatoria de X</param>
        /// <returns>Lista de valores de promedios de X y Y ademas de sumatorias y numero total de evaluaciones</returns>
        private List<double> Promedios(List<double> vX, List<double> vY, double sumXy, double sumXx)
        {
            double promX = 0.0;
            double promY = 0.0;
            double evalQuan = vX.Count;

            if (vX.Count != vY.Count)
            {
                return null;
            }
            else
            {
                foreach (var iX in vX)
                {
                    foreach (var iY in vY)
                    {
                        //(2,3,4,5,6) (3,4,5,6,4)
                        promX += iX;
                        promY += iY;
                    }
                }
                promX /= evalQuan;
                promY /= evalQuan;
            }

            List<double> vs = new List<double>()
            {
                promX,
                promY,
                sumXx,
                sumXy,
                evalQuan
            };

            return vs;
        }

    }
}
