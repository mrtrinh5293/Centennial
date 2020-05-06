package com.example.fragment_assignment;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    public static final String EXTRA_MESSAGE = "com.example.myfirstapp.MESSAGE";

    Button b1;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toast.makeText(getApplicationContext(), "First onCreate() calls", Toast.LENGTH_LONG).show();
//        b1 = (Button)  findViewById(R.id.btnAI);
//        b1.setOnClickListener(new View.OnClickListener() {
//
//            @Override
//            public void onClick(View v) {
//            Intent intent = new Intent(MainActivity.this, AIActivity.class);
//                Toast toast=Toast.makeText(getApplicationContext(),"onCreateCalled",Toast.LENGTH_SHORT);
////                AIActivity(intent);
//            }
//        });
    }


    public void AIActivity(View view){
        Intent intent = new Intent(this, AIActivity.class);
        Toast toast=Toast.makeText(getApplicationContext(),"onCreateCalled",Toast.LENGTH_SHORT);
        intent.putExtra(EXTRA_MESSAGE, toast.toString());
        startActivity(intent);
    }
    protected void onStart()
    {
        super.onStart();
        Toast.makeText(getApplicationContext(),"Now onStart() calls", Toast.LENGTH_LONG).show(); //onStart Called
    }

}