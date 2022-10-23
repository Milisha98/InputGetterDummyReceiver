namespace TE.Events;

public record FileReceivedEvent(string OriginalFile,
                                string BackupFile,
                                string[] Lines,
                                string TransactionGroupType);

