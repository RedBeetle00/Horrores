using UnityEngine;
using UnityEngine.UI;
using Common;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class TerminalScript : MonoBehaviour
{
    [SerializeField] private Text OutputText;

    public InputField InputCommand;
    private IPsData IPs_Data;
    private IPgenerator IPsGenerator;
    private bool AnimationPlayed;
    
    //private bool isProcessing = false;
    private static string CurrentCommand = "";

    private void AddDelay(float seconds)
    {
        StartCoroutine(DelayCoroutine(seconds));
    }

    private IEnumerator DelayCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    public void GetCommand()
    {
        CurrentCommand = InputCommand.text;
    }

    void Start()
    {
        IPsGenerator = FindFirstObjectByType<IPgenerator>();

        LoadIPsData();
    }

    private IEnumerator ScanAnimation()
    {
        if (!AnimationPlayed)
        {
            OutputText.text += "Scanning network: [.";
            for (int i = 0; i < 6; i++)
            {
                yield return new WaitForSeconds(0.3f);
                OutputText.text += ".";
            }
        }
        OutputText.text += "]\n";
        // Открываем доступ к ПЕРВОМУ IP (он уже существует)
        AnimationPlayed = true;
        CommonVar.FirstIPreached = true;
        OutputText.text += $"Detected IP!\nIP: {IPs_Data.ipAddresses[0]}\nIP automatically copied.\n";
        GUIUtility.systemCopyBuffer = IPs_Data.ipAddresses[0];
    }

    private IEnumerator DecryptAnimation()
    {
        OutputText.text += "Decrypting encoded IP...\n";
        yield return new WaitForSeconds(2f);
        
        // Открываем доступ ко ВТОРОМУ IP (он уже существует)
        CommonVar.SecondIPreached = true;
        OutputText.text += $"IP decrypted: {IPs_Data.ipAddresses[1]}\nIP copied";
        GUIUtility.systemCopyBuffer = IPs_Data.ipAddresses[1];
    }

    private IEnumerator FindVulnerabilityAnimation()
    {
        OutputText.text += "Scanning for vulnerabilities...\n";
        yield return new WaitForSeconds(1f);
        
        OutputText.text += "Analyzing ports: 22, 80, 443, 3389\n";
        yield return new WaitForSeconds(1f);
        
        OutputText.text += "Found open port: 22 (SSH)\n";
        yield return new WaitForSeconds(1f);
        
        OutputText.text += "Attempting SSH brute force...\n";
        
        // Анимация подбора пароля
        string[] attempts = { "admin:12345 X", "root:password X", "guest:guest X", "user:qwerty V" };
        foreach (string attempt in attempts)
        {
            yield return new WaitForSeconds(0.8f);
            OutputText.text += attempt + "\n";
        }
        
        yield return new WaitForSeconds(1f);
        OutputText.text += "V SSH access granted!\n";
        
        // Открываем доступ к ТРЕТЬЕМУ IP
        CommonVar.ThirdIPreached = true;
        OutputText.text += $"Compromised server IP: {IPs_Data.ipAddresses[2]}\nIP copied.";
        GUIUtility.systemCopyBuffer = IPs_Data.ipAddresses[2];
    }

    private IEnumerator ADAttackAnimation()
    {
        OutputText.text += "Initializing Active Directory reconnaissance...\n";
        yield return new WaitForSeconds(1.5f);
        
        OutputText.text += "Querying Domain Controllers...\n";
        yield return new WaitForSeconds(2f);
        
        OutputText.text += "DC identified: DC01.CORP.LOCAL\n";
        yield return new WaitForSeconds(1f);
        
        OutputText.text += "Enumerating user accounts via LDAP...\n";
        yield return new WaitForSeconds(2f);
        
        OutputText.text += "Found 247 user accounts\n";
        yield return new WaitForSeconds(1f);
        
        OutputText.text += "Attempting Kerberoasting attack...\n";
        yield return new WaitForSeconds(2f);
        
        OutputText.text += "Extracting service account TGS tickets\n";
        yield return new WaitForSeconds(2f);
        
        OutputText.text += "Cracking TGS tickets offline...\n";
        yield return new WaitForSeconds(2f);
        
        OutputText.text += "Service account password compromised: 'SRV_Backup@2024!'\n";
        yield return new WaitForSeconds(1f);
        
        OutputText.text += "Domain Admin privileges obtained\n";
        
        CommonVar.FourthIPreached = true;
        OutputText.text += $"Domain Controller IP: {IPs_Data.ipAddresses[3]}\n";
        GUIUtility.systemCopyBuffer = IPs_Data.ipAddresses[3];
        OutputText.text += "Domain persistence established. Ready for data exfiltration.\nIP copied\n";
    }

    private IEnumerator BruteForceAnimation()
    {
        string targetPassword = "K7$9mP@q2";
        int maxAttempts = 5;
        int attempts = 0;
        bool passwordFound = false;

        OutputText.text += "Starting brute-force attack on encrypted vault...\n";
        yield return new WaitForSeconds(1f);
        
        OutputText.text += "Password pattern detected: 8 chars, mixed case, symbols\n";
        yield return new WaitForSeconds(1f);

        while (attempts < maxAttempts && !passwordFound)
        {
            attempts++;
            OutputText.text += $"\nAttempt {attempts}/{maxAttempts}: ";
            
            // Имитация генерации пароля
            string attempt = GenerateRandomAttempt();
            OutputText.text += $"{attempt}";
            
            yield return new WaitForSeconds(1f);

            if (attempt == targetPassword)
            {
                passwordFound = true;
                OutputText.text += " - SUCCESS!\n";
            }
            else
            {
                OutputText.text += " - FAILED\n";
                
                // Подсказки после неудачных попыток
                if (attempts == 2)
                    OutputText.text += "Hint: Contains special character $\n";
                else if (attempts == 3)
                    OutputText.text += "Hint: Starts with uppercase letter\n";
                else if (attempts == 4)
                    OutputText.text += "Hint: Has number 7 in position 2\n";
            }
        }

        if (passwordFound)
        {
            OutputText.text += "\nVAULT UNLOCKED!\n";
            OutputText.text += $"Master Password: {targetPassword}\n";
            GUIUtility.systemCopyBuffer = targetPassword;
        }
        else
        {
            OutputText.text += "\nToo many failed attempts. System locked.\n";
        }
    }

    private string GenerateRandomAttempt()
    {
        string[] attempts = {
            "Password1", "Admin123", "K7$9mP@q2", "Welcome1", "Qwerty123"
        };
        return attempts[Random.Range(0, attempts.Length)];
    }

    private void LoadIPsData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "generated_ips.json");;
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            IPs_Data = JsonUtility.FromJson<IPsData>(json);
            Debug.Log("IPs data loaded successfully");
        }
    }

    public void ProcessCommand()
    {
        if (string.IsNullOrEmpty(CurrentCommand))
        {
            Debug.LogError("CurrentCommand is null or empty!");
            return;
        }

        string command = CurrentCommand.ToLower().Trim();

        switch(command)
        {
            case "help":
                Debug.Log("HELP");
                if (OutputText != null)
                    OutputText.text += "Available commands: help, scan, decrypt, clear, list_ips, exploit, kerberoast\n";
                else
                    Debug.LogError("OutputText is null!");
                break;
            case "scan":
                Debug.Log("SCAN");
                if (OutputText != null)
                    StartCoroutine(ScanAnimation());
                break;
            case "decrypt":
                Debug.Log("DECRYPT");
                if (OutputText != null)
                    StartCoroutine(DecryptAnimation());
                break;
            case "clear":
                if (OutputText != null)
                    OutputText.text = "";
                break;
            case "list_ips":
                if (OutputText != null)
                {
                    OutputText.text += $"Collected IPs:\n";
                    
                    if (IPs_Data?.ipAddresses == null || IPs_Data.ipAddresses.Count == 0)
                    {
                        OutputText.text += "No IPs available\n";
                        break;
                    }
                    if (CommonVar.FirstIPreached && IPs_Data.ipAddresses.Count > 0)
                        OutputText.text += $"{IPs_Data.ipAddresses[0]}\n";
                    else
                        OutputText.text += $"Not collected yet\n";
                        
                    if (CommonVar.SecondIPreached && IPs_Data.ipAddresses.Count > 1)
                        OutputText.text += $"{IPs_Data.ipAddresses[1]}\n";
                    else
                        OutputText.text += $"Not collected yet\n";
                        
                    if (CommonVar.ThirdIPreached && IPs_Data.ipAddresses.Count > 2)
                        OutputText.text += $"{IPs_Data.ipAddresses[2]}\n";
                    else
                        OutputText.text += $"Not collected yet\n";
                        
                    if (CommonVar.FourthIPreached && IPs_Data.ipAddresses.Count > 3)
                        OutputText.text += $"{IPs_Data.ipAddresses[3]}\n";
                    else
                        OutputText.text += $"Not collected yet\n";
                }
                break;
            case "exploit":
                Debug.Log("EXPLOIT");
                if (OutputText != null)
                    StartCoroutine(FindVulnerabilityAnimation());
                break;
            case "kerberoast":
                if (OutputText != null)
                    StartCoroutine(ADAttackAnimation());
                break;
            case "getkey":
                if (CommonVar.FirstIPreached && CommonVar.SecondIPreached && CommonVar.ThirdIPreached && CommonVar.FourthIPreached)
                {
                    CommonVar.AllIPsCollected = true;
                    OutputText.text += $"All IPs collected!\n";
                    AddDelay(2f);
                    StartCoroutine(BruteForceAnimation());
                }
                else
                {
                    OutputText.text += $"Collect all IPs before using this command";
                }
                break;
            default:
                Debug.Log($"Unknown command: {command}");
                if (OutputText != null)
                    OutputText.text += $"Command not found: {command}\n";
                break;
        }

        if (InputCommand != null)
            InputCommand.text = "";
    }
}
