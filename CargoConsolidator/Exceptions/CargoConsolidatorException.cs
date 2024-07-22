using System;

namespace CargoConsolidator.Exceptions
{
    /// <summary>
    /// Необработанное исключение консолидатора грузов
    /// </summary>
    public class CargoConsolidatorException : Exception
    {
        public CargoConsolidatorException(string message)
            : base(message) { }
    }
}
