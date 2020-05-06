package com.example.final_assignment_03;

import android.app.Activity;
import android.graphics.drawable.AnimationDrawable;
import android.graphics.drawable.BitmapDrawable;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;

public class Exercise1 extends Activity {
    AnimationDrawable mframeAnimation = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.exercise1);
        //
//        // Handle Start Button
//        final Button onButton = (Button) findViewById(R.id.ButtonStart);
//        onButton.setOnClickListener(new View.OnClickListener() {
//            public void onClick(View v) {
//                startAnimation();
//            }
//        });
//
//        // Handle Stop Button
//        final Button offButton = (Button) findViewById(R.id.ButtonStop);
//        offButton.setOnClickListener(new View.OnClickListener() {
//            public void onClick(View v) {
//                stopAnimation();
//            }
//        });
//    }
//
//    //
//
//    private void startAnimation()
//    {
//
//        ImageView img = (ImageView)findViewById(R.id.ImageView_Boy);
//        BitmapDrawable frame1 = (BitmapDrawable)getResources().getDrawable(R.drawable.giphy0);
//        BitmapDrawable frame2 = (BitmapDrawable)getResources().getDrawable(R.drawable.giphy1);
//        BitmapDrawable frame3 = (BitmapDrawable)getResources().getDrawable(R.drawable.giphy2);
//        BitmapDrawable frame4 = (BitmapDrawable)getResources().getDrawable(R.drawable.giphy3);
//        BitmapDrawable frame5 = (BitmapDrawable)getResources().getDrawable(R.drawable.giphy4);
//        BitmapDrawable frame6 = (BitmapDrawable)getResources().getDrawable(R.drawable.giphy5);
//        // Get the background, which has been compiled to an AnimationDrawable object.
//        int reasonableDuration = 250;
//        mframeAnimation = new AnimationDrawable();
//        mframeAnimation.setOneShot(false);	// loop continuously
//        mframeAnimation.addFrame(frame1, reasonableDuration);
//        mframeAnimation.addFrame(frame2, reasonableDuration);
//        mframeAnimation.addFrame(frame3, reasonableDuration);
//        mframeAnimation.addFrame(frame4, reasonableDuration);
//        mframeAnimation.addFrame(frame5, reasonableDuration);
//        mframeAnimation.addFrame(frame6, reasonableDuration);
//        mframeAnimation.addFrame(frame6, reasonableDuration);
//        mframeAnimation.addFrame(frame6, reasonableDuration);
//
//        img.setBackgroundDrawable(mframeAnimation);
//
//        mframeAnimation.setVisible(true,true);
//        mframeAnimation.start();
//    }
//    private void stopAnimation()
//    {
//        mframeAnimation.stop();
//        mframeAnimation.setVisible(false,false);
//
//    }
    }
}
