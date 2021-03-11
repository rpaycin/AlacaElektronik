using Admin.Entity;

namespace Admin.DataLayer.Helper
{
    public static class Converter
    {
        private static bool _isInitiliazed;
        private static readonly object LockObject = new object();
        public static void Init()
        {
            lock (LockObject)
            {
                if (_isInitiliazed) return;

                AutoMapper.Mapper.CreateMap<User, Kullanicilar>()
                    .ForMember(m => m.Sifre, opt => opt.MapFrom(src => src.Password))
                    .ForMember(m => m.Email, opt => opt.MapFrom(src => src.EmailAddress))
                    .ForMember(m => m.KullaniciId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(m => m.KullaniciAdi, opt => opt.MapFrom(src => src.FullName));

                AutoMapper.Mapper.CreateMap<Kullanicilar, User>()
                    .ForMember(m => m.Password, opt => opt.MapFrom(src => src.Sifre))
                    .ForMember(m => m.EmailAddress, opt => opt.MapFrom(src => src.Email))
                    .ForMember(m => m.Id, opt => opt.MapFrom(src => src.KullaniciId))
                    .ForMember(m => m.FullName, opt => opt.MapFrom(src => src.KullaniciAdi));

                AutoMapper.Mapper.CreateMap<Entity.User, User>();
                AutoMapper.Mapper.CreateMap<Firm, Entity.Firm>();
                AutoMapper.Mapper.CreateMap<Urun, Entity.Product>();
                AutoMapper.Mapper.CreateMap<Product, Urun>();
                AutoMapper.Mapper.CreateMap<UrunGrup, Entity.ProductGroup>();
                AutoMapper.Mapper.CreateMap<ProductGroup, UrunGrup>();

                _isInitiliazed = true;
            }
        }

        public static K Convert<T, K>(T input)
        {
            Init();
            return input != null ?
                AutoMapper.Mapper.Map<T, K>(input) :
                default(K);
        }
    }
}
