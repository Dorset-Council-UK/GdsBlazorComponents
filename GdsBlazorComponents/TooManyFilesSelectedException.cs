using System;

namespace GdsBlazorComponents
{
    public class TooManyFilesSelectedException : Exception
    {
        public int MaxAllowedFiles { get; }
        public int ActualFileCount { get; }

        public TooManyFilesSelectedException(int maxAllowedFiles, int actualFileCount)
            : base($"Too many files selected. Maximum allowed is {maxAllowedFiles}, but {actualFileCount} were selected.")
        {
            MaxAllowedFiles = maxAllowedFiles;
            ActualFileCount = actualFileCount;
        }
    }
}