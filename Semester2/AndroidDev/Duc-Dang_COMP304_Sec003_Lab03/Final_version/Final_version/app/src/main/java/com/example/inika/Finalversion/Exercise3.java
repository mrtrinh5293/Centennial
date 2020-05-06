package com.example.inika.Finalversion;

import android.app.Activity;

import android.graphics.Color;
import android.graphics.drawable.Drawable;
import android.graphics.drawable.ShapeDrawable;
import android.graphics.drawable.shapes.RectShape;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.RadioButton;

import android.os.Bundle;
import android.widget.Toast;

public class Exercise3 extends Activity implements AdapterView.OnItemSelectedListener  {
    Integer[] pixel = { 10, 20, 30  };
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.exercise3);

        final Spinner spin = (Spinner) findViewById(R.id.spinner1);
        ArrayAdapter<Integer> adapter = new ArrayAdapter<Integer>(this, android.R.layout.simple_spinner_item, pixel);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spin.setAdapter(adapter);
        spin.setOnItemSelectedListener(this);

        final RadioButton radio_red = (RadioButton) findViewById(R.id.radio_red);
        final RadioButton radio_yellow = (RadioButton) findViewById(R.id.radio_yellow);
        final RadioButton radio_green = (RadioButton) findViewById(R.id.radio_green);


        // Handle Line Button
        final Button ButtonLine = (Button) findViewById(R.id.ButtonLine);


        ButtonLine.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                Integer spinpixel = spin.getSelectedItemPosition();
                // Create a line from a rectangle
                ShapeDrawable d = new ShapeDrawable(new RectShape());
                d.setIntrinsicHeight(4);
                d.setIntrinsicWidth(300);
                if (spinpixel == 0){
                    d.setIntrinsicHeight(4);
                    d.setIntrinsicWidth(300);
                }
                if (spinpixel == 1){
                    d.setIntrinsicHeight(4);
                    d.setIntrinsicWidth(200);
                }
                if (spinpixel == 2){
                    d.setIntrinsicHeight(4);
                    d.setIntrinsicWidth(100);
                }
                if (radio_red.isChecked()) {
                    d.getPaint().setColor(Color.RED);
                }
                if (radio_yellow.isChecked()){
                    d.getPaint().setColor(Color.YELLOW);
                }
                if (radio_green.isChecked()){
                    d.getPaint().setColor(Color.GREEN);
                }
//                d.getPaint().setColor(Color.MAGENTA);
                setShapeByDrawable(d);
            }
        });
        final Button btn_clear = (Button) findViewById(R.id.btn_clear);

        btn_clear.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                ImageView ImageViewShape = (ImageView) findViewById(R.id.ImageViewForShape);

                ImageViewShape.setImageResource(0);
            }
        });
    }


    private void setShapeByDrawable(Drawable drawable) {
        // We will animate the imageview
        ImageView reusableImageView = (ImageView) findViewById(R.id.ImageViewForShape);
        reusableImageView.setImageDrawable(drawable);
    }
    public void onItemSelected (AdapterView < ? > arg0, View arg1,int position, long id){
        Toast.makeText(getApplicationContext(), "Selected User: " + pixel[position], Toast.LENGTH_SHORT).show();
    }
    @Override
    public void onNothingSelected (AdapterView < ? > arg0){
        // TODO - Custom Code
    }

}
