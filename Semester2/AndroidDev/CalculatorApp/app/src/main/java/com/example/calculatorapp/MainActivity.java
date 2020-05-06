package com.example.calculatorapp;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.text.Editable;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Button;

public class MainActivity extends AppCompatActivity {

    EditText num1;
    EditText num2;
    TextView result;
    Button buttonDiv;
    Button buttonSub;
    Button buttonMul;
    Button buttonAdd;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        num1 = (EditText)findViewById((R.id.editTextNum1));
        num2 = (EditText)findViewById((R.id.editTextNum2));

        buttonAdd = (Button) findViewById((R.id.buttonAdd));
        buttonSub = (Button) findViewById((R.id.buttonSub));
        buttonMul = (Button) findViewById((R.id.buttonMul));
        buttonDiv = (Button) findViewById((R.id.buttonDiv));

        result = (TextView) findViewById((R.id.textViewResult));

        buttonAdd.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                double number1 = Double.parseDouble(num1.getText().toString());
                double number2 = Double.parseDouble(num2.getText().toString());
                double sum = number1 + number2;
                result.setText(Double.toString(sum));
            }
        });
        buttonSub.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                double number1 = Double.parseDouble(num1.getText().toString());
                double number2 = Double.parseDouble(num2.getText().toString());
                double sub = number1 - number2;
                result.setText(Double.toString(sub));
            }
        });
        buttonMul.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                double number1 = Double.parseDouble(num1.getText().toString());
                double number2 = Double.parseDouble(num2.getText().toString());
                double mul = number1 * number2;
                result.setText(Double.toString(mul));
            }
        });
        buttonDiv.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                double number1 = Double.parseDouble(num1.getText().toString());
                double number2 = Double.parseDouble(num2.getText().toString());
                double div = number1 / number2;
                result.setText(Double.toString(div));
            }
        });
    }



    public void buttonDiv_clicked(View view) {
//        result.setText(());
    }

    public void buttonSub_clicked(View view) {
    }

    public void buttonMul_clicked(View view) {
    }

    public void buttonAdd_clicked(View view) {

    }
}
