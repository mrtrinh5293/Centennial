package com.example.switchexample;

import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Switch;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    private Switch sw1,sw2;
    private  Button btnGet;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        sw1 = (Switch)findViewById(R.id.switch1);
        sw2 = (Switch)findViewById(R.id.switch2);
        btnGet = (Button)findViewById(R.id.getBtn);
        btnGet.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String str1, str2;
                if (sw1.isChecked())
                    str1 = sw1.getTextOn().toString();
                else
                    str1 = sw1.getTextOff().toString();
                if (sw2.isChecked())
                    str2 = sw2.getTextOn().toString();
                else
                    str2 = sw2.getTextOff().toString();
                Toast.makeText(getApplicationContext(), "Switch1 -  " + str1 + " \n" + "Switch2 - " + str2,Toast.LENGTH_SHORT).show();
            }
        });
    }
}
