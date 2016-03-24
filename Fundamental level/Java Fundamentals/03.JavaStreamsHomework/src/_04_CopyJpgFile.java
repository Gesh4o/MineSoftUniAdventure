import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class _04_CopyJpgFile {
    private static final String sourcePath = "src\\my-picture.jpg";
    private static final String destinationPath = "src\\my-copied-picture.jpg";
    public static void main(String[] args) {
        try(FileInputStream fileInputStream = new FileInputStream(sourcePath)){
            byte[] buffer = new byte[4096];

            try(FileOutputStream fileOutputStream = new FileOutputStream(destinationPath, true)){
                while(true){
                    int bytesRead  = fileInputStream.read(buffer);
                    if (bytesRead == -1){
                        break;
                    }

                    fileOutputStream.write(buffer,0, bytesRead);
                }
            }
        }
        catch (IOException ioe){
            System.out.println(ioe);
        }
    }
}
