package com.example.zd.teablendnfcreader;

import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.widget.Toast;

import java.io.BufferedWriter;
import java.io.IOException;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;

public class UpdateActivity extends AppCompatActivity {

    private String ip;
    private String cusNo;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_update);

        Bundle bundle = getIntent().getExtras();
        cusNo = bundle.getString("cusNo", "ye");
        ip = bundle.getString("ip");
        // new BGWorker().execute(cusNo);

        Log.i("NFO", cusNo + "");

        BGWorker worker = new BGWorker();
        worker.execute(cusNo);

    }

    private class BGWorker extends AsyncTask<String, Void, String> {




        @Override
        protected String doInBackground(String... strings) {

            //String loginUrl = "http://" + ip + "/tbc/update.php";
            String loginUrl = "http://192.168.22.11/tbc/update.php";

            try {
                Log.i("NFO", "err before open set");
                String cusNo = strings[0];

                Log.i("NFO", "err before open conn");
                URL url = new URL(loginUrl);
                HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();
                httpURLConnection.setConnectTimeout(5000);
                Log.i("NFO", "err before connection");

                httpURLConnection.setRequestMethod("POST");
                httpURLConnection.setDoInput(true);
                httpURLConnection.setDoOutput(true);


                Log.i("NFO", "err before outputstream");
                OutputStream outputStream = httpURLConnection.getOutputStream();
                BufferedWriter bufferedWriter = new BufferedWriter(
                        new OutputStreamWriter(outputStream, "UTF-8"));

                String postData =
                        URLEncoder.encode("cusNo", "UTF-8") + "=" + URLEncoder.encode(cusNo, "UTF-8");

                bufferedWriter.write(postData);
                bufferedWriter.flush();
                bufferedWriter.close();
                outputStream.close();

//                InputStream inputStream = httpURLConnection.getInputStream();
//                BufferedReader bufferedReader = new BufferedReader(
//                        new InputStreamReader(inputStream, cusNo));
//
//                String result = "";
//                String line;
//                while ((line = bufferedReader.readLine()) != null) {
//                    result += line;
//                }
//
//                bufferedReader.close();
//                inputStream.close();
//                httpURLConnection.disconnect();

                Log.i("NFO", "no err");

//                return result;

            } catch(IOException e) {
                Log.e("ERR", "Error in conn: " + e.getMessage());
                e.printStackTrace();
            }

            return null;
        }

        @Override
        protected void onPreExecute() {
            //super.onPreExecute();
            //mLoadingDialog = ProgressDialog.show(UpdateActivity.this, "Please wait", "Loading...");

        }

        @Override
        protected void onPostExecute(String s) {
            //super.onPostExecute(s);
            //mLoadingDialog.dismiss();

            // check if connected
            if (s == null) {
                Toast.makeText(getApplicationContext(), "Please connect to the internet. " + ip, Toast.LENGTH_SHORT).show();
                return;
            }

            String out = s.trim();

            if(!s.equals("fail")) {
                // show dialog success
                Toast.makeText(getApplicationContext(), "Success!", Toast.LENGTH_SHORT).show();
            } else {
                Toast.makeText(getApplicationContext(), "Invalid Card!\nPlease contact Teablend", Toast.LENGTH_SHORT).show();
            }

            Log.i("NFO", "Login NFO: " + out);

        }
    }

}
