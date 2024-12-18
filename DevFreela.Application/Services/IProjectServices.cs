using DevFreela.Application.Models;

namespace DevFreela.Application.Services;

public interface IProjectServices
{
    ResultViewModel<List<ProjectItemViewModel>> GetAll(string search = "",int page = 0, int size = 3);
    ResultViewModel<ProjectViewModel> GetById (int id);
    ResultViewModel<int> Insert(CreateProjectInputModel model);
    ResultViewModel Start(int id);
    ResultViewModel Complete(int id);
    ResultViewModel Delete(int id);
    ResultViewModel Update (UpdateProjectInputModel model);
    ResultViewModel InsertComments(int id, CreateProjectCommentInputModel model);
}