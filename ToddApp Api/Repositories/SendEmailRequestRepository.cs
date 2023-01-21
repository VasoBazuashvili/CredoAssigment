﻿using ToddApp_Api.DB;
using ToddApp_Api.Entities;

namespace ToddApp_Api.Repositories
{
	public interface ISendEmailRequestRepository
	{
		void Insert(SendEmailRequestEntity entity);
		Task SaveChangesAsync();
	}

	public class SendEmailRequestRepository : ISendEmailRequestRepository
	{
		private readonly AppDbContext _db;

		public SendEmailRequestRepository(AppDbContext db)
		{
			_db = db;
		}

		public void Insert(SendEmailRequestEntity entity)
		{
			_db.SendEmailRequests.Add(entity);
		}

		public async Task SaveChangesAsync()
		{
			await _db.SaveChangesAsync();
		}
	}
}
