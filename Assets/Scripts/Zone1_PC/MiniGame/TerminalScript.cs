// TerminalScript.cs
using UnityEngine;
using UnityEngine.UI;
using Common;
using System.Collections;
using UnityEngine.SceneManagement;

public class TerminalScript : MonoBehaviour
{
    [SerializeField] private Text OutputText;
    public InputField InputCommand;
    
    private bool AnimationPlayed;
    
    private IPsData IPs_Data => IPDataManager.GetIPsData();

    public void GetCommand()
    {
        // Теперь команда обрабатывается напрямую из InputField
    }

    void Start()
    {
        // Предварительная загрузка данных
        if (!IPDataManager.HasData())
        {
            OutputText.text += "System ready. Type 'help' for available commands.\n";
        }
        else
        {
            OutputText.text += $"System loaded. {IPs_Data.ipAddresses.Count} IPs available.\n";
        }
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
            OutputText.text += "]\n";
        }
        
        AnimationPlayed = true;
        CommonVar.FirstIPreached = true;
        
        if (IPs_Data.ipAddresses.Count > 0)
        {
            OutputText.text += $"Detected IP!\nIP: {IPs_Data.ipAddresses[0]}\nIP automatically copied.\n";
            GUIUtility.systemCopyBuffer = IPs_Data.ipAddresses[0];
        }
        else
        {
            OutputText.text += "Error: No IPs available. Generate IPs first.\n";
        }
    }

    private IEnumerator DecryptAnimation()
    {
        OutputText.text += "Decrypting encoded IP...\n";
        yield return new WaitForSeconds(2f);
        
        CommonVar.SecondIPreached = true;
        
        if (IPs_Data.ipAddresses.Count > 1)
        {
            OutputText.text += $"IP decrypted: {IPs_Data.ipAddresses[1]}\nIP copied\n";
            GUIUtility.systemCopyBuffer = IPs_Data.ipAddresses[1];
        }
        else
        {
            OutputText.text += "Error: Second IP not available.\n";
        }
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
        
        string[] attempts = { "admin:12345 X", "root:password X", "guest:guest X", "user:qwerty V" };
        foreach (string attempt in attempts)
        {
            yield return new WaitForSeconds(0.8f);
            OutputText.text += attempt + "\n";
        }
        
        yield return new WaitForSeconds(1f);
        OutputText.text += "V SSH access granted!\n";
        
        CommonVar.ThirdIPreached = true;
        
        if (IPs_Data.ipAddresses.Count > 2)
        {
            OutputText.text += $"Compromised server IP: {IPs_Data.ipAddresses[2]}\nIP copied.\n";
            GUIUtility.systemCopyBuffer = IPs_Data.ipAddresses[2];
        }
        else
        {
            OutputText.text += "Error: Third IP not available.\n";
        }
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
        
        if (IPs_Data.ipAddresses.Count > 3)
        {
            OutputText.text += $"Domain Controller IP: {IPs_Data.ipAddresses[3]}\n";
            GUIUtility.systemCopyBuffer = IPs_Data.ipAddresses[3];
            OutputText.text += "Domain persistence established. Ready for data exfiltration.\nIP copied\n";
        }
        else
        {
            OutputText.text += "Error: Fourth IP not available.\n";
        }
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
            OutputText.text += $"Master Password: {targetPassword}\nYou won!";
            GUIUtility.systemCopyBuffer = targetPassword;
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("GoodEnd");
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

    public void ProcessCommand()
    {
        string command = InputCommand.text.ToLower().Trim();

        if (string.IsNullOrEmpty(command))
        {
            Debug.LogError("Command is null or empty!");
            return;
        }

        if (OutputText == null)
        {
            Debug.LogError("OutputText is not assigned!");
            return;
        }

        switch(command)
        {
            case "help":
                OutputText.text += "Available commands: help, scan, decrypt, clear, list_ips, exploit, kerberoast, getkey\n";
                break;
            case "scan":
                StartCoroutine(ScanAnimation());
                break;
            case "decrypt":
                StartCoroutine(DecryptAnimation());
                break;
            case "clear":
                OutputText.text = "";
                break;
            case "list_ips":
                OutputText.text += $"Collected IPs:\n";
                
                if (!IPDataManager.HasData())
                {
                    OutputText.text += "No IPs available. Generate IPs first.\n";
                    break;
                }

                OutputText.text += CommonVar.FirstIPreached && IPs_Data.ipAddresses.Count > 0 ? 
                    $"{IPs_Data.ipAddresses[0]}\n" : "Not collected yet\n";
                    
                OutputText.text += CommonVar.SecondIPreached && IPs_Data.ipAddresses.Count > 1 ? 
                    $"{IPs_Data.ipAddresses[1]}\n" : "Not collected yet\n";
                    
                OutputText.text += CommonVar.ThirdIPreached && IPs_Data.ipAddresses.Count > 2 ? 
                    $"{IPs_Data.ipAddresses[2]}\n" : "Not collected yet\n";
                    
                OutputText.text += CommonVar.FourthIPreached && IPs_Data.ipAddresses.Count > 3 ? 
                    $"{IPs_Data.ipAddresses[3]}\n" : "Not collected yet\n";
                break;
            case "exploit":
                StartCoroutine(FindVulnerabilityAnimation());
                break;
            case "kerberoast":
                StartCoroutine(ADAttackAnimation());
                break;
            case "getkey":
                if (CommonVar.FirstIPreached && CommonVar.SecondIPreached && CommonVar.ThirdIPreached && CommonVar.FourthIPreached)
                {
                    CommonVar.AllIPsCollected = true;
                    OutputText.text += $"All IPs collected!\n";
                    StartCoroutine(BruteForceAnimation());
                }
                else
                {
                    OutputText.text += $"Collect all IPs before using this command\n";
                } 
                break;
            default:
                OutputText.text += $"Command not found: {command}\n";
                break;
        }

        InputCommand.text = "";
    }
}