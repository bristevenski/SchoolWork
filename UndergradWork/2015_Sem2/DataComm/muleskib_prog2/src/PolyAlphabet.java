/**
Uses Caesar cipher to encrypt a message.
@author Brianna Muleski
*/
public class PolyAlphabet 
{
    final int ASCII = 64;
    final int UPPER_BOUNDARY = 27;
    final int LOWER_BOUNDARY = 59;
    final int WRAPAROUND = 26;
    final int C_1 = 5;
    final int C_2 = 19;
    final int PATTERN_BOUND = 5;
    
    /**
    Encrypts the given message using the Caesar ciphers.
    @param message the string to encrypt
    @return the encrypted message
    */
    public String Encrypt(String message)
    {
        String encrypt_msg = "";
        int curr_cipher;
        int curr_pos = 1;
        
        for (int i = 0; i < message.length(); i++)
        {
            char ch = message.charAt(i);
            if (Character.isLetter(ch))
            {
                curr_cipher = UpdateCipher(curr_pos);
                encrypt_msg += Caesar(ch, curr_cipher);
                
                if (curr_pos == PATTERN_BOUND)
                {
                    curr_pos = 1;
                }
                else
                {
                    curr_pos++;
                }
            }
            else
            {
                encrypt_msg += ch;
            }
        }
        return encrypt_msg;
    }
    
    /**
    Converts the plaintext character given to the ciphertext character 
    associated with that character.
    @param ch the plaintext letter
    @param cipher the Caesar cipher 
    @return the ciphertext letter
    */
    private char Caesar(char ch, int cipher)
    {
        char c_ch;
        int ascii_ch = (int) ch - ASCII;
        
        for (int i = 0; i < cipher; i++)
        {
            ascii_ch++;
            if (ascii_ch == UPPER_BOUNDARY || ascii_ch == LOWER_BOUNDARY)
            {
                ascii_ch -= 26;
            }
        }
        
        c_ch = (char) (ascii_ch + ASCII);
        
        return c_ch;
    }

    /**
    Updates the Caesar cipher used according to the following pattern:
    C1, C2, C2, C1, C2.
    @param pos the current position in the pattern
    @return the next cipher to use in the pattern
    */
    private int UpdateCipher(int pos) 
    {
        int cipher = 0;
        switch (pos)
        {
            case 1: cipher = C_1;
                    break;
            case 2: cipher = C_2;
                    break;
            case 3: cipher = C_2;
                    break;
            case 4: cipher = C_1;
                    break; 
            case 5: cipher = C_2;
                    break;
        }
        
        return cipher;
    }
}
