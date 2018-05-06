

namespace MyWebAPI
{
    public class Grade
    {

		public int StudentID { get; set; }
		public int CourseID { get; set; }

		private int m_score;

		public int Score
		{
			get
			{
				return m_score;
			}
			set
			{
				if (value >= 100)
				{
					m_score = 100;
				}
				else if (value <= 0)
				{
					m_score = 0;
				}
				else
				{
					m_score = value;
				}
			}
		}

	}
}
