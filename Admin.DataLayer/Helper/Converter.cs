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

                AutoMapper.Mapper.CreateMap<User, Entity.User>();
                AutoMapper.Mapper.CreateMap<Entity.User, User>();
                AutoMapper.Mapper.CreateMap<Firm, Entity.Firm>();
                AutoMapper.Mapper.CreateMap<Firm, OptionList>()
                    .ForMember(m => m.ID, opt => opt.MapFrom(src => src.FirmID))
                    .ForMember(m => m.Value, opt => opt.MapFrom(src => src.FirmName));

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
