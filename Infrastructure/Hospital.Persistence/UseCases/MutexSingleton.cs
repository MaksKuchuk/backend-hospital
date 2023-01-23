namespace Hospital.Persistence.UseCases;

public class MutexSingleton
{
    private static MutexSingleton instance;

    private readonly Dictionary<Guid, Mutex> _mutexAppointment;

    private MutexSingleton()
    {
        _mutexAppointment = new Dictionary<Guid, Mutex>();
    }

    public static MutexSingleton getInstance()
    {
        if (instance == null)
        {
            instance = new MutexSingleton();
        }

        return instance;
    }

    public Dictionary<Guid, Mutex> getMutexAppointnetn()
    {
        return _mutexAppointment;
    }
}