﻿using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.GetAllProjects;

public class GetAllProjectsQuery : IRequest<ResultViewModel<List<ProjectItemViewModel>>>
{
    public GetAllProjectsQuery(string search = "", int page = 0, int size = 3)
    {

        Search = search;
        Page = page;
        Size = size;
    }
    public string Search { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
}