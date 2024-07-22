using System;

namespace CargoConsolidator
{
    /// <summary>
    /// Билдер консолидатора. Только через него можно получить консолидатор
    /// </summary>
    public class CargoConsolidatorBuilder
    {
        /// <summary>
        /// Установить строку подключения к базе данных
        /// </summary>
        public CargoConsolidatorBuilder SetConnectionString(string connectionString)
        {
            throw new NotImplementedException();

            return this;
        }

        /// <summary>
        /// Создать консолидатор
        /// </summary>
        public ICargoConsolidator Build()
        {
            throw new NotImplementedException(); 
        }
    }
}
