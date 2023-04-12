using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.ViewModels;
using DataRepository.IServiceRepo;
using WebSerino.Data;

namespace BusinessLogic.Business
{
    public class ActivationLogic : IActivationLogic
    {
        private readonly ISerinoRepoService _serinoRepoService;
        private readonly IMapper _mapper;

        public ActivationLogic(ISerinoRepoService serinoRepoService, IMapper mapper)
        {
            _serinoRepoService = serinoRepoService;
            _mapper = mapper;
        }

        public List<ActivationViewModel> GetAllActivation()
        {
            try
            {
                var data = _serinoRepoService.GetAllActivation();
                var response = _mapper.Map<List<ActivationViewModel>>(data);
                return response;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Response CreateActivation(ActivationViewModel data)
        {
            try
            {
                var outcome = _mapper.Map<Activation>(data);
                outcome.DeviceType = outcome.SerialNumber[0..2] switch
                {
                    "AT" => "Fox",
                    "RD" => "Rhino",
                    "FS" => "FoxS",
                };
                var result = _serinoRepoService.CreateActivation(outcome);
                if (result)
                {
                    return new Response(Status.Success, "Tạo Thành Công");
                }
                return new Response(Status.Failure, "Thất bại");
            }
            catch (Exception)
            {
                return new Response(Status.Failure, "Thất bại");
                throw;
            }
        }

        public Response DeleteActivation(ActivationViewModel data)
        {
            var outcome = _mapper.Map<Activation>(data);
            var result = _serinoRepoService.DeleteActivation(outcome);
            if (result)
            {
                return new Response(Status.Success, "Xóa Thành Công");
            }
            return new Response(Status.Failure, "Thất bại");
        }

        public List<SerinoViewModel> GetInfoActivationBySerino(string serino)
        {
            var result = _serinoRepoService.GetActivationBySerino(serino);
            if (result != null)
            {
                var response = _mapper.Map<List<SerinoViewModel>>(result);
                return response;
            }
            return null;
        }
    }
}
