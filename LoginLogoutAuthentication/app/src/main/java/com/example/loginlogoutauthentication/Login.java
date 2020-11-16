package com.example.loginlogoutauthentication;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.Toast;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;

public class Login extends AppCompatActivity {
    public static final String TAG = "TAG";
    private EditText loginPageEmail, loginPagePassword;
    private Button loginPage_registerBtn,loginPage_loginBtn;
    ProgressBar progressBar;

    FirebaseAuth fAuth;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        loginPageEmail=findViewById(R.id.loginPage_emailR);
        loginPagePassword=findViewById(R.id.loginPage_passwordR);
        progressBar = findViewById(R.id.progressBar);

        loginPage_loginBtn=findViewById(R.id.loginPage_loginBtn);

        loginPage_registerBtn = findViewById(R.id.loginPage_registerBtn);
        fAuth = FirebaseAuth.getInstance();
        attachJavaObjectToXML();

        loginPage_loginBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String email = loginPageEmail.getText().toString().trim();
                String password = loginPagePassword.getText().toString().trim();

                if(TextUtils.isEmpty(email)){
                    loginPageEmail.setError("Email is Required.");
                    return;
                }

                if(TextUtils.isEmpty(password)){
                    loginPagePassword.setError("Password is Required.");
                    return;
                }

                progressBar.setVisibility(View.VISIBLE);

                // authenticate the user
                try {
                    fAuth.signInWithEmailAndPassword(email, password)
                            .addOnCompleteListener( new OnCompleteListener<AuthResult>() {
                        @Override
                        public void onComplete(@NonNull Task<AuthResult> task) {
                            if(task.isSuccessful()){
                                Log.d(TAG, "signInWithEmail:success");
                                FirebaseUser user = fAuth.getCurrentUser();

                                String uid = user.getUid();
                                System.out.println(uid);

                                Log.d("User Iddsdddd: ",uid);

//                                updateUI(user);
                                Toast.makeText(Login.this, "Logged in Successfully", Toast.LENGTH_SHORT).show();
                                startActivity(new Intent(getApplicationContext(),MainActivity.class));
                            }else {
                                Toast.makeText(Login.this, "Error ! " + task.getException().getMessage(), Toast.LENGTH_SHORT).show();
                                progressBar.setVisibility(View.GONE);
                            }
                        }
                    });
                } catch (Exception e) {
                    System.out.println(e.getMessage());
                    System.out.println(email);
                    System.out.println(password);
                }


            }
        });
    }

    private void moveToRegisterPage(){
        try{
            startActivity(new Intent( getApplicationContext(), RegisterPage.class));
        } catch (Exception e){

        }
    }

    private void attachJavaObjectToXML() {
        try {

//            objectRelativeLayout = findViewById(R.id.lo)



            loginPage_registerBtn.setOnClickListener (new View.OnClickListener() {
                @Override
                public void onClick(View view){
                    moveToRegisterPage();
                }
            });
        }
        catch (Exception e) {
            Toast.makeText(this,"LoginPage: "+e.getMessage(), Toast.LENGTH_SHORT).show();
        }
    }
}