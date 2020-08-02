using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory.Services
{
	public class ProgramService
	{
		public DataTable GetAllPrograms()
		{
			using (ProgramDAC programDAC = new ProgramDAC())
			{
				return programDAC.GetAllPrograms();
			}
		}			

		public ProgramVO GetProgram(int prog_id)
		{
			using (ProgramDAC programDAC = new ProgramDAC())
			{
				return programDAC.GetProgram(prog_id);
			}
		}

		public bool SaveProgram(ProgramVO ProgramVO)
		{
			using (ProgramDAC programDAC = new ProgramDAC())
			{
				return programDAC.SaveProgram(ProgramVO);
			}
		}

		public bool DeleteProgram(string prog_id)
		{
			using (ProgramDAC programDAC = new ProgramDAC())
			{
				return programDAC.DeleteProgram(prog_id);
			}
		}
	}
}
