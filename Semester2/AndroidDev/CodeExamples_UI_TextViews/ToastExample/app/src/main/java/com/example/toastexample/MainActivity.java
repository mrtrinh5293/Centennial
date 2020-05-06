package com.example.toastexample;

import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;
import android.view.Gravity;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Button btn = (Button)findViewById(R.id.btnShow);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Toast.makeText(MainActivity.this, "You Clicked on Button..", Toast.LENGTH_SHORT).show();
                //Toast toast =  Toast.makeText(MainActivity.this, "You Clicked on Button..", Toast.LENGTH_SHORT);
                //toast.setGravity(Gravity.TOP|Gravity.RIGHT, 100, 250);
                //toast.show();
            }
        });
    }
}