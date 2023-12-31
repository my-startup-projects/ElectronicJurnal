﻿using ElectronicJournal.Shared.DTOs.TeacherDto;
using ElectronicJournal.Shared.Response;
using ElectronicJournal.Shared.Entity;
using ElectronicJournal.Shared.DTOs.JournalDto;

namespace ElectronicJournal.Server.Services.Teachers
{
	public interface ITeachersService
	{
		Task<ServiceResponse<bool>> AddTeacher(CreateTeacherDto teacherDto);
		Task<ServiceResponse<bool>> RemoveTeacher(Guid teacherId);
		Task<ServiceResponse<List<Teacher>>> GetTeachers();
		Task<ServiceResponse<GetTeacherDto>> UpdateTeacher(UpdateTeacherDto updateTeacherDto);
		Task<ServiceResponse<List<GetJournalDto>>> GetJournals(Guid teacherId);

	}
}
