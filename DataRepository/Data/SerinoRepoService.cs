using DataRepository.IServiceRepo;
using WebSerino.Data;

namespace DataRepository.Data
{
    public class SerinoRepoService : ISerinoRepoService
    {
        private readonly DataContext _context;
        public SerinoRepoService(DataContext context)
        {
            _context = context;
        }

        public List<Activation> GetAllActivation()
        {
            try
            {
                List<Activation> device = _context.Activations.Where(x => x.Disabled == false)
                                          .OrderByDescending(x => x.DateAdded)
                                          .ToList();
                return device;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteActivation(Activation data)
        {
            try
            {
                var outcome = _context.Activations.FirstOrDefault(x => x.SerialNumber == data.SerialNumber && x.Disabled == false);
                if (outcome != null)
                {
                    outcome.Disabled = true;
                    _context.Update(outcome);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool CreateActivation(Activation data)
        {
            try
            {
                Activation activation = _context.Activations.FirstOrDefault(x => x.SerialNumber == data.SerialNumber);
                if (activation != null && activation.Disabled == false)
                {
                    return false;
                }
                if (activation != null && activation.Disabled == true)
                {
                    activation.Disabled = false;
                    activation.DateModified = DateTime.Now;
                    _context.Activations.Update(activation);
                    _context.SaveChanges();
                    return true;
                }
                if (activation == null)
                {
                    data.DateAdded = DateTime.UtcNow;
                    _context.Activations.Add(data);
                    _context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public List<Activation> GetActivationBySerino(string serino)
        {
            try
            {
                List<Activation> device = _context.Activations.Where(x => x.SerialNumber == serino)
                                          .OrderByDescending(x => x.DateAdded)
                                          .ToList();
                return device;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
