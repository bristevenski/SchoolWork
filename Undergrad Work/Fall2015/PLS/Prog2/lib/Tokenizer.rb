# Tokenizer.rb
# Holds the Tokenizer class.
# Author: Brianna Muleski
require_relative "Scanner.rb"

# Evaluates the input and tokenizes it based on what each part of the
# input represents: identifier, number, comment, string, or operator.
# Outputs the results.
class Tokenizer
    
    # initializes the Tokenizer object. Creates a Scanner object and sets
    # the reserved words.
    def initialize
        @scanner = Scanner.new
        @reserved_words =
        {
            "begin" => 1,
            "end" => 2,
            "require" => 3,
            "def" => 4,
            "class" => 5,
            "if" => 6,
            "while" => 7,
            "else" => 8,
            "elsif" => 9,
            "for" => 10,
            "return" => 11,
            "and" => 12,
            "or" => 13
        }
    end # end of initialize
    
    # Analyzes the input until the end tokenizer is found. Identifies what
    # each part of the input represents by analyzing the next character from
    # the input.
    def run
        done = false
        while not done
            ch = @scanner.get_next_char
            if ch =~ /[a-zA-Z_]/
                do_identifier(ch)
            elsif ch =~ /[0-9]/
                do_number(ch)
            elsif ch == "#"
                do_comment(ch)
            elsif ch == '"'
                do_string(ch)
            elsif ch =~ /[\s]/
                ; 
            elsif ch == '?'
                puts "End Token: ?"
                done = true
            else
                do_operator(ch)
            end
        end
    end # end of run

    # Gets the identifier found in the input. Analyzes each character to check
    # for the end of the identifier. If the identifier is a reserved word, 
    # it finds the number corresponding to that word. 
    # Outputs the results.
    def do_identifier(ch)
        iden = ch
        done = false
        while not done
            ch1 = @scanner.get_next_char
            if ch1 =~ /[a-zA-Z0-9_]/
                iden += ch1
            else
                done = true
                @scanner.push_back(ch1) if ch1 =~ /[\S]/
            end
        end
        resv = @reserved_words[iden]
        if resv == nil
            puts "Identifier: " + iden
        else
            puts "Reserved Word: " + iden + " - " + resv.to_s
        end
    end # end of do_identifier()

    # Gets the number (integer only) found in the input. Analyzes each 
    # character to check for the end of the number. 
    # Outputs the results.
    def do_number(ch)
        str = ch
        done = false
        while not done
            ch1 = @scanner.get_next_char
            if ch1 =~ /[0-9]/
                str += ch1
            else
                done = true
                @scanner.push_back(ch1)
            end
        end
        puts "Number: " + str
    end # end of do_number()

    # Gets the comment found in the input. Analyzes each 
    # character to check for the end of the comment (end of line). 
    # Outputs the results.
    def do_comment(ch)
        str = ch
        done = false
        while not done
            ch1 = @scanner.get_next_char
            if ch1 == "\n"
                done = true
            else
                str += ch1
            end
        end
        puts "Comment: " + str
    end # end of do_comment()

    # Gets the operator found in the input. Analyzes each 
    # character to check for the end of the operator. 
    # Outputs the results.
    def do_operator(ch)
        str = ch
        if ch =~ /[<>=!+\-\*\/%\|~&\^]/
            ch1 = @scanner.get_next_char
            if ch1 == "="
                str += ch1
            else
                @scanner.push_back(ch1)
            end
        elsif ch == '.'
            ch1 = @scanner.get_next_char
            if ch1 == '.'
                str += ch1
                ch2 = @scanner.get_next_char
                if ch2 == '.'
                    str += ch2 
                else
                    @scanner.push_back(ch2)
                end
            else
                @scanner.push_back(ch1)
            end
        end
        puts "Operator: " + str
    end # end of do_operator()

    # Gets the string found in the input. Analyzes each 
    # character to check for the end of the string ("). If the end of the
    # string is not found, set the output as bad.
    # Outputs the results.
    def do_string(ch)
        str = ch
        done = false
        escaped = false
        while not done
            ch1 = @scanner.get_next_char
            if ch1 == "\n"
                done = true
                puts "Bad String: " + str
                return
            elsif ch1 == '\\'
                str = str + ch1
                escaped = true
            elsif ch1 == '"'
                str = str + ch1
                if not escaped
                    done = true
                puts "String: " + str
                end
                escaped = false
            else
                str = str + ch1
                escaped = false
            end
        end
    end # end of do_string()
end #end of Tokenizer class
