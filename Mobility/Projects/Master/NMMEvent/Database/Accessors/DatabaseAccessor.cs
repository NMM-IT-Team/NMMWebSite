using System.Collections.Generic;
using System.Threading.Tasks;
using Database.DatabaseContext;
using Database.Accessors.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace Database.Accessors
{
	public class DatabaseAccessor : IDatabaseEngine
	{
		EventDatabaseContext _databaseContext;

		public async Task<List<DCEvents>> GetEventsAsync()
		{
			try
			{
				//TODO: This call needs to be shifted in the constructor or something?
				await AddEvent();
				await AddEventDetails();

				//This is very bad
				_databaseContext = new EventDatabaseContext();

				var result = await _databaseContext.NMMEvent.ToListAsync();
				return result;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}

			return null;
		}

		public async Task<DCEventDetails> GetEventDetailsByEventIdAsync(int EventId)
		{
			try
			{
				_databaseContext = new EventDatabaseContext();
				var result = await _databaseContext.NMMEventDetails
												   .Where(x => x.EventId == EventId)
												   .FirstAsync();
				return result;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}

			return null;
		}

		public async Task AddEvent()
		{
			try
			{
				var pathForAndroidSystem = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				var path = string.Format("{0}/{1}", pathForAndroidSystem, "EventsDatabase.db");
				if (!File.Exists(path))
				{
					if (_databaseContext == null)
					{
						_databaseContext = new EventDatabaseContext();
					}

					await _databaseContext.Database.MigrateAsync();
					await _databaseContext.NMMEvent.AddRangeAsync(DCEvents.GenerateEventSeedScriptObjects());
					await _databaseContext.SaveChangesAsync();
				}

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
		}

		public async Task AddEventDetails()
		{
			try
			{
				var pathForAndroidSystem = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				var path = string.Format("{0}/{1}", pathForAndroidSystem, "EventsDatabase.db");
				if (File.Exists(path))
				{
					if (_databaseContext == null)
					{
						_databaseContext = new EventDatabaseContext();
					}

					await _databaseContext.Database.MigrateAsync();
					await _databaseContext.NMMEventDetails.AddRangeAsync(DCEventDetails.GenerateEventDetailsSeedScriptObjects());
					await _databaseContext.SaveChangesAsync();
				}

			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
		}

	}
}
