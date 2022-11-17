﻿using SQLite;

namespace CajeroMovil.Services
{
    public static class Constants
    {
        private const string DBFileName = "SQLite.db3";

        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite
            | SQLiteOpenFlags.Create
            | SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {

            get
            {
                return Path.Combine(FileSystem.AppDataDirectory, DBFileName);
                //return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DBFileName);
            }
        }
    }
}
