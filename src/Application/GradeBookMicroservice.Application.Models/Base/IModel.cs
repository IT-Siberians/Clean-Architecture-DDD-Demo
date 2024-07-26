namespace GradeBookMicroservice.Application.Models;

public interface IModel<out TId> where TId : struct
{
    public TId Id {get; }

}
