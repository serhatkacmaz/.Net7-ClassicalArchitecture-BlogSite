using AutoMapper;

namespace BlogSite.Service.Mapping
{
    /// <summary>
    /// Aktif değil.
    /// </summary>
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MasterProfile>();
                cfg.AddProfile<TransactionProfile>();
                cfg.AddProfile<UserBaseProfile>();
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }
}
