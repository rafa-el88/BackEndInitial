
using PositivoCore.Domain.Entities;
using System.Collections.Generic;

namespace PositivoCore.Application.Interface.Repository
{
	public interface ITurmaDisciplinaProfessorRepository 
	{
		List<TurmaDisciplinaProfessor> InsertList(List<TurmaDisciplinaProfessor> obj);
	}
}
