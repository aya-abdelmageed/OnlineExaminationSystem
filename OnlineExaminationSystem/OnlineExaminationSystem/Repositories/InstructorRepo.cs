using AutoMapper;
using DataAccess;
using OnlineExaminationSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExaminationSystem.Repositories
{
    internal class InstructorRepo
    {

        private readonly DBManager _dbManager;
        private readonly IMapper _mapper;

        public InstructorRepo( IMapper mapper)
        {
            _dbManager = new DBManager();
            _mapper = mapper;
        }

        public List<InstructorDTO> GetInstructors()
        {
            string procedureName = "INSTRUCTOR_VIEW"; // Stored procedure name
            DataTable dataTable = _dbManager.ExecuteStoredProcedure(procedureName, null);

            List<InstructorDTO> instructors = new List<InstructorDTO>();
            foreach (DataRow row in dataTable.Rows)
            {
               instructors.Add(_mapper.Map<InstructorDTO>(row));

            }

            return instructors;
        }

    }
}
