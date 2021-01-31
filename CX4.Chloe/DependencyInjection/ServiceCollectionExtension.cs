using System;
using CX4.Chloe;
using CX4.Chloe.Oracle;
using CX4.Domain.Repository;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        public static void AddChloeDbContext(this IServiceCollection services, Action<CholeDbContextOptionsBuilder> options)
        {
            options(new CholeDbContextOptionsBuilder(services));
            services.AddScoped<ISqlRepository, SqlRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CholeDbContextOptionsBuilder
    {
        private IServiceCollection _services;
        public CholeDbContextOptionsBuilder(IServiceCollection services)
        {
            _services = services;
        }

        /// <summary>
        /// 使用oracle数据库
        /// </summary>
        /// <param name="readerConnectionStr"></param>
        /// <param name="writerConnectionStr"></param>
        public void UseOracle(string readerConnectionStr, string writerConnectionStr)
        {
            _services.AddScoped<IDbReaderContext>(k => new OracleReaderContext(new OracleConnectionFactory(readerConnectionStr)));
            _services.AddScoped<IDbWriterContext>(k => new OracleWriterContext(new OracleConnectionFactory(writerConnectionStr)));
        }
    }
}
