import os
import sys

input_dir = 'X:/lemmatization-lists-master/'
output_dir = 'X:/lemmatization-lists-master/fixed/'



for file in os.listdir(input_dir):

    if '.txt' in file:

        print(file)

        with open(input_dir + file, 'r', encoding='utf-8-sig') as incoming, open(output_dir + 'manual-' + file, 'w', newline='', encoding='utf-8-sig') as outgoing:

            for line in incoming:

                line_split = line.replace('\r', '').replace('\n', '').split('\t')
                #print(line_split)

                if len(line_split) > 1:

                    #if file != "lemmatization-fa.txt":
                    
                        outgoing.write(line_split[1] + '^' + line_split[0] + '\r\n')

                    #else:

                    #    outgoing.write(line_split[0] + '^' + line_split[1] + '\r\n')

                
