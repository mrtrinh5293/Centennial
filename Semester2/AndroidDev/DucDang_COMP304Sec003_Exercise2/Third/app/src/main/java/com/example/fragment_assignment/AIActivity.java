package com.example.fragment_assignment;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.Toast;

import com.example.fragment_assignment.ui.ai.AiFragment;

public class AIActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Toast.makeText(getApplicationContext(), "First onCreate() calls", Toast.LENGTH_LONG).show(); //onCreate called
    }
        @Override
        protected void onStart()
        {
            super.onStart();
            Toast.makeText(getApplicationContext(),"Now onStart() calls", Toast.LENGTH_LONG).show(); //onStart Called
        }
    }
