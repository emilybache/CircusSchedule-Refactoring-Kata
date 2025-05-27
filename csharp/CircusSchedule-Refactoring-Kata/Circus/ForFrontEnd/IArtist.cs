namespace Circus.ForFrontEnd;

public interface IArtist
{
    public string Id { get; }
    public string Name { get; }
    
    public List<Skill> Skills { get; }

}