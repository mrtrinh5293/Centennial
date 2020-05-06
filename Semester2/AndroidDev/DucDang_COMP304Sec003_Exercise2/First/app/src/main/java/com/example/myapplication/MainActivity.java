package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.DialogInterface;
import android.os.Bundle;
import android.service.autofill.OnClickAction;
import android.text.Editable;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Button;
import android.app.AlertDialog;
import android.widget.Toast;
import android.view.Gravity;
import android.widget.DatePicker;
import android.widget.RadioButton;
import android.widget.RadioGroup;



public class MainActivity extends AppCompatActivity implements AdapterView.OnItemSelectedListener {

    TextView result;
    TextView Date;
    DatePicker picker;
    EditText field1;
//    EditText field2;
//    EditText field3;
    Button button_calculating;
    Integer[] years = { 1, 2, 3, 4 ,5 };
    RadioGroup radioRate;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        final Spinner spin = (Spinner) findViewById(R.id.spinner1);
        ArrayAdapter<Integer> adapter = new ArrayAdapter<Integer>(this, android.R.layout.simple_spinner_item, years);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spin.setAdapter(adapter);
        spin.setOnItemSelectedListener(this);

        String text = spin.getSelectedItem().toString();
        Date = (TextView)findViewById(R.id.Date);
        picker = (DatePicker)findViewById(R.id.datePicker1);
        field1 = (EditText)findViewById((R.id.loanAmount));

        radioRate = (RadioGroup) findViewById(R.id.radioRate);

        button_calculating = (Button) findViewById(((R.id.buttonCal)));

        result = (TextView) findViewById((R.id.totalLoan));

        button_calculating.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                final String radiovalue = ((RadioButton)findViewById(radioRate.getCheckedRadioButtonId())).getText().toString();

                if(field1.getText().length() > 0 && radioRate.getCheckedRadioButtonId() != -1){
                    AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                    builder.setTitle("Login Alert")
                            .setMessage("Are you sure, you want to continue ?")
                            .setCancelable(false)
                            .setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                                @Override
                                public void onClick(DialogInterface dialog, int which) {
                                    String text = spin.getSelectedItem().toString();
                                    Toast.makeText(MainActivity.this,"Loan Duration: " + text + " - year",Toast.LENGTH_SHORT).show();
                                    Toast.makeText(MainActivity.this,"Interest: " + radiovalue + "%",Toast.LENGTH_SHORT).show();
                                    double number1 = Double.parseDouble(field1.getText().toString());
                                    double number2 = Double.parseDouble(text);
                                    double number3 = Double.parseDouble(radiovalue);
                                    double rate = number1 * number2 * (number3 / 100);
                                    result.setText(Double.toString(rate));
                                    Date.setText("Selected Date: "+ picker.getDayOfMonth()+"/"+ (picker.getMonth() + 1)+"/"+picker.getYear());
                                }
                            })
                            .setNegativeButton("No", new DialogInterface.OnClickListener() {
                                @Override
                                public void onClick(DialogInterface dialog, int which) {
//                                    Toast.makeText(MainActivity.this,"Selected Option: No",Toast.LENGTH_SHORT).show();
                                }
                            });
                    //Creating dialog box
                    AlertDialog dialog  = builder.create();
                    dialog.show();
                } else {
                    Toast toast =Toast.makeText(MainActivity.this,"Please Enter Requirement Field", Toast.LENGTH_SHORT);
                    toast.setGravity(Gravity.BOTTOM|Gravity.CENTER,100,250);
                    toast.show();
                }
            }
        });

            // setup the alert builder

    }
    @Override
    public void onItemSelected(AdapterView<?> arg0, View arg1, int position,long id) {
//        Toast.makeText(getApplicationContext(), "Selected Number: "+years[position] ,Toast.LENGTH_SHORT).show();
    }
    @Override
    public void onNothingSelected(AdapterView<?> arg0) {
        // TODO - Custom Code
    }
}
