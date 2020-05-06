package com.example.edittextexample;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import org.w3c.dom.Text;

public class MainActivity extends AppCompatActivity {
    Button btnSubmit;
    EditText name, password, email, dob, phoneno;
    TextView result;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        name=(EditText)findViewById(R.id.txtName);
        password = (EditText)findViewById(R.id.txtPwd);
        email = (EditText)findViewById(R.id.txtEmail);
        dob = (EditText)findViewById(R.id.txtDate);
        phoneno= (EditText)findViewById(R.id.txtPhone);
        btnSubmit = (Button)findViewById(R.id.btnSend);
        result = (TextView)findViewById(R.id.resultView);
        btnSubmit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (name.getText().toString().isEmpty() || password.getText().toString().isEmpty() || email.getText().toString().isEmpty() || dob.getText().toString().isEmpty()
                        || phoneno.getText().toString().isEmpty()) {
                    result.setText("Please Fill All the Details");
                } else {
                    result.setText("Name -  " + name.getText().toString() + " \n" + "Password -  " + password.getText().toString()
                            + " \n" + "E-Mail -  " + email.getText().toString() + " \n" + "DOB -  " + dob.getText().toString()
                            + " \n" + "Contact -  " + phoneno.getText().toString());
                }
            }
        });
    }
}
