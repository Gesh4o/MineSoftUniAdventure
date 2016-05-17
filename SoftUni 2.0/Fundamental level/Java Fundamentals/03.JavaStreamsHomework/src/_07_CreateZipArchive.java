import java.io.*;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

public class _07_CreateZipArchive {
    private static final String path = "src\\text-files.zip";

    public static void main(String[] args) {
        try(ZipOutputStream zipOutputStream = new ZipOutputStream(new BufferedOutputStream(new FileOutputStream(path)))){
            String[] paths = new String[2];
            paths[0] = "src\\lines.txt";
            paths[1] = "src\\words.txt";
            String[] zipPaths = new String[]{"lines.txt", "words.txt"};
            for (int i = 0; i < paths.length; i++) {
                try(BufferedInputStream bufferedInputStream = new BufferedInputStream(new FileInputStream(paths[i]))){
                    byte[] buffer = new byte[4096];

                    while (true){
                        int byteRead = bufferedInputStream.read(buffer);

                        if (byteRead == - 1){
                            break;
                        }

                        zipOutputStream.putNextEntry(new ZipEntry(zipPaths[i]));
                        zipOutputStream.write(buffer);

                        zipOutputStream.closeEntry();
                    }
                }
            }
        }
        catch (IOException e){
            System.out.println(e);
        }
    }
}
