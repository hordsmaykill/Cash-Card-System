package com.example.zd.teablendnfcreader;

import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.widget.TextView;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;

public class UpdateActivity extends AppCompatActivity {

    private SharedPreferences prefs;
    private String ip;

    private String id;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_update);

        prefs = getSharedPreferences("prefs", MODE_PRIVATE);
        ip = prefs.getString("ip", "10.0.0.2");
        // ip = "192.168.1.13";

        Bundle extras = getIntent().getExtras();
        id = extras.getString("result");
        Toast.makeText(this, "result: " + id, Toast.LENGTH_SHORT).show();
        new BGWorker().execute(id);

    }


    private class BGWorker extends AsyncTask<String, Void, String>{
        Dialog mLoadingDialog;

        @Override
        protected void onPreExecute() {
            //super.onPreExecute();
            mLoadingDialog = ProgressDialog.show(UpdateActivity.this, "Please wait", "Loading...");
        }

        @Override
        protected String doInBackground(String... strings) {

            String loginUrl = "http://" + ip + "/tbc/update.php";

            try {
                String cusNo = strings[0];

                URL url = new URL(loginUrl);
                HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();
                httpURLConnection.setConnectTimeout(3000);
                httpURLConnection.setReadTimeout(3000);

                httpURLConnection.setRequestMethod("POST");
                httpURLConnection.setDoInput(true);
                httpURLConnection.setDoOutput(true);

                OutputStream outputStream = httpURLConnection.getOutputStream();
                BufferedWriter bufferedWriter = new BufferedWriter(
                        new OutputStreamWriter(outputStream,"UTF-8"));

                String postData =
                        URLEncoder.encode("cusNo","UTF-8") + "=" +
                                URLEncoder.encode(cusNo, "UTF-8");

                bufferedWriter.write(postData);
                bufferedWriter.flush();
                bufferedWriter.close();
                outputStream.close();

                InputStream inputStream = httpURLConnection.getInputStream();
                BufferedReader bufferedReader = new BufferedReader(
                        new InputStreamReader(inputStream, "UTF-8"));

                String result = "";
                String line;
                while ((line = bufferedReader.readLine()) != null) {
                    result += line;
                }

                bufferedReader.close();
                inputStream.close();
                httpURLConnection.disconnect();

                Log.i("NFO", "no err");

                return result;

            } catch(IOException e) {
                Log.e("ERR", "Error in login: " + e.getMessage());
            }

            return null;
        }



        @Override
        protected void onPostExecute(String result) {
            //super.onPostExecute(s);
            mLoadingDialog.dismiss();

            // check if connected
            if (result == null) {
                Toast.makeText(UpdateActivity.this, "Check internet connection", Toast.LENGTH_SHORT).show();
                return;
            }

            Log.i("NFO", "Result: " + result);
            
            String out = result.trim();
            if(result.equals("success")) {
                Toast.makeText(UpdateActivity.this, "Updated!!!", Toast.LENGTH_SHORT).show();
            } else {
                Toast.makeText(UpdateActivity.this, "An error has occured", Toast.LENGTH_SHORT).show();
            }
            Log.i("NFO", "Login NFO: " + out);

            TextView txtID = (TextView) findViewById(R.id.txtID);
            txtID.setText(id);

        }
    }

}
