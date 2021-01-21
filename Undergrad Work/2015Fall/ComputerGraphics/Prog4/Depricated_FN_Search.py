import os

#oldfun = ["TBD","GL.Begin","GL.VertexPointer","GL.ColorPointer","GL.GetDouble","GL.Rotate","Gl.Scale","GL.Translate","GL.MatrixMode","GL.EnableClientState","GL.LoadMatrix","GL.Material","GL.LightModel","GL.PushMatrix","GL.Frustum","GL.Light"]
oldfun = open("Deprecated FnSearch.txt", 'r').read().split('|')
outfile = open("outfile.txt", 'w+')
for filename in os.listdir(os.getcwd()):
        if filename[-2:] == 'cs':
                searchfile = open(filename, 'r')
                linenum = 0
                for line in searchfile:
                        linenum = linenum + 1
                        for function in oldfun:
                           if function in line:
                                outfile.write(filename + " : " + str(linenum) + " ; " +line+ '\n')
                                print(filename + " : " + str(linenum) + " ; " +line)
outfile.close()
