package com.example.inika.Finalversion;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.Button;
import android.widget.ImageView;

public class Exercise2 extends Activity {
	private ImageView imageMoon2;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.exercise2);

		imageMoon2 = (ImageView) findViewById(R.id.imageMoon);
		final Button btn_stop = (Button) findViewById(R.id.btn_stop);

		btn_stop.setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				imageMoon2.clearAnimation();
				imageMoon2.setVisibility(View.VISIBLE);
			}
		});


		final Button btn_trans = (Button)findViewById(R.id.btn_trans);
		btn_trans.setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				performAnimation(R.anim.shakennotstirred);
			}
		});

	}

//    private void clearAnimation(Animation animation){
//
//    }

	private void performAnimation(int animationResourceID)
	{
		// We will animate the imageview
		ImageView reusableImageView = (ImageView)findViewById(R.id.imageMoon);
//            reusableImageView.setImageResource(R.drawable.imageMoon);
		reusableImageView.setVisibility(View.VISIBLE);

		// Load the appropriate animation
		Animation an =  AnimationUtils.loadAnimation(this, animationResourceID);
		// Register a listener, so we can disable and re-enable buttons
		an.setAnimationListener(new MyAnimationListener());
		// Start the animation
		reusableImageView.startAnimation(an);
	}
	class MyAnimationListener implements Animation.AnimationListener {

		public void onAnimationEnd(Animation animation) {
			// Hide our ImageView
			ImageView reusableImageView = (ImageView)findViewById(R.id.imageMoon);
//            reusableImageView.setVisibility(View.INVISIBLE);

			// Enable all buttons once animation is over
//            toggleButtons(true);

		}

		public void onAnimationRepeat(Animation animation) {
			// what to do when animation loops
		}

		public void onAnimationStart(Animation animation) {
			// Disable all buttons while animation is running
//            toggleButtons(false);

		}

	}
}
