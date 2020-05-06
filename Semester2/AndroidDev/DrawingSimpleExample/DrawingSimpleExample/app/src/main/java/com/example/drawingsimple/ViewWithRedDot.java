package com.example.drawingsimple;

// Import the following
import android.graphics.Paint;
import android.graphics.Canvas;
import android.graphics.Color;
import android.view.View;
import android.content.Context;

public class ViewWithRedDot extends View {
    public ViewWithRedDot(Context context) {
        super(context);
    }
    @Override
    protected void onDraw(Canvas canvas) {
        canvas.drawColor(Color.GREEN);
        Paint circlePaint = new Paint();
        circlePaint.setColor(Color.RED);
        canvas.drawCircle(canvas.getWidth()/2,
                canvas.getHeight()/2,
                canvas.getWidth()/3, circlePaint);
    }
}