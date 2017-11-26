using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenGLStart.test
{
    public class OpenGLStart
    {
        private static float zoom;
        private static float x_angle;
        
        [STAThread]
        public static void Main()
        {
            using (var game = new GameWindow())
            {
                game.Load += (sender, e) =>
                {
                    // setup settings, load textures, sounds
//                    game.VSync = VSyncMode.On;
                    GL.ClearColor(Color.Black);
                    GL.Enable(EnableCap.DepthTest);
            
                    Matrix4 p = Matrix4.CreatePerspectiveFieldOfView((float)(80 * Math.PI / 180), 1, 20, 500);
                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadMatrix(ref p);

                    Matrix4 modelview = Matrix4.LookAt(70, 70, 70, 0, 0, 0, 0, 1, 0);
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadMatrix(ref modelview);
                    
                    float[] light_position = { 20.0f, 20.0f, 20.0f, 1.0f };
                    GL.Light(LightName.Light0, LightParameter.Position, light_position);
                    GL.Enable(EnableCap.Lighting);
                    GL.Enable(EnableCap.Light0);
//                    GL.Enable(EnableCap.ColorMaterial);
//                    GL.Material(MaterialFace.Front, MaterialParameter.Emission, new float[] { 0.3f, 0.3f, 0.3f, 1.0f });
                };
 
                game.Resize += (sender, e) =>
                {
                    GL.Viewport(0, 0, game.Width, game.Height);
                };
 
                game.UpdateFrame += (sender, e) =>
                {
                    // add game logic, input handling
                    if (game.Keyboard[Key.Escape])
                    {
                        game.Exit();
                    }

                    if (game.Mouse[OpenTK.Input.MouseButton.Left])
                    {
                        x_angle = game.Mouse.X;
                        
                    }
                    else
                       //x_angle += 0.5f;

                    if (game.Keyboard[Key.M])
                    {
                        GL.Disable(EnableCap.ColorMaterial);
                        GL.Enable(EnableCap.ColorMaterial);
                        GL.Material(MaterialFace.Front, MaterialParameter.Ambient, new float[] { 0.3f, 0.3f, 0.3f, 1.0f });
                    }
                    
                    if (game.Keyboard[Key.K])
                    {
                        GL.Disable(EnableCap.ColorMaterial);
//                        GL.Enable(EnableCap.ColorMaterial);
//                        GL.Material(MaterialFace.Front, MaterialParameter.Ambient, new float[] { 0.3f, 0.3f, 0.3f, 1.0f });
                    }
                    if (game.Keyboard[Key.E])
                    {
                        GL.Disable(EnableCap.ColorMaterial);
                        GL.Enable(EnableCap.ColorMaterial);
                        GL.Material(MaterialFace.Front, MaterialParameter.Emission, new float[] { 0.3f, 0.3f, 0.3f, 1.0f });
                    }
                    if (game.Keyboard[Key.D])
                    {
                        GL.Disable(EnableCap.ColorMaterial);
                        GL.Enable(EnableCap.ColorMaterial);
                        GL.Material(MaterialFace.Front, MaterialParameter.Diffuse, new float[] { 0.5f, 0.5f, 0.5f, 1.0f });
                    }
                    
                    if (game.Keyboard[Key.S])
                    {
                        GL.Disable(EnableCap.ColorMaterial);
                        GL.Enable(EnableCap.ColorMaterial);
                        GL.Material(MaterialFace.Front, MaterialParameter.Shininess, new float[] { 0.3f, 0.3f, 0.3f, 1.0f });
                    }

                    zoom = game.Mouse.Wheel * 0.5f;   // Mouse.Wheel is broken on both Linux and Windows.

                    // Do not leave x_angle drift too far away, as this will cause inaccuracies.
                    if (x_angle > 360.0f)
                        x_angle -= 360.0f;
                    else if (x_angle < -360.0f)
                        x_angle += 360.0f;
                    
//                    Matrix4d projection_matrix;//Матрица 4x4, элементы типа double
//                    GL.GetDouble(GetPName.ProjectionMatrix, out projection_matrix);//Загружаем матрицу проецирования в projection_matrix
//
////Подготавливаем матрицу поворота вокруг оси OZ                
//                    double cos = Math.Cos(x_angle * Math.PI / 180);
//                    double sin = Math.Sin(x_angle * Math.PI / 180);
//
//                    Matrix4d rotating_matrix = new Matrix4d(
//                        cos, -sin, 0, 0,
//                        sin, cos,  0, 0,
//                        0,     0,  1, 0,
//                        0,     0,  0, 1
//                    );
//
//                    projection_matrix *= rotating_matrix;//умножаем матрицу проецирования на матрицу поворота
//                    GL.MatrixMode(MatrixMode.Projection);//переходим в режим проецирования
//                    GL.LoadMatrix(ref projection_matrix);//устанавливаем новую матрицу проецирования
//                    GL.Material(MaterialFace.Front, MaterialParameter.Ambient, new float[] { 0.3f, 0.3f, 0.3f, 1.0f });
                };
                
              
 
                game.RenderFrame += (sender, e) =>
                {
                    // render graphics
//                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                    float width = 20;            
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                    Matrix4 lookat = Matrix4.LookAt(-20.5f + zoom, -20.5f + zoom, -20.5f + zoom, 0, 0, 0, 0, 1, 0);
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadMatrix(ref lookat);

//                    if (!(rotate_matrix[0] == 0 && rotate_matrix[1] == 0 && rotate_matrix[2] == 0))
//                    {
//                        Matrix4d projection_matrix;//Матрица 4x4, элементы типа double
//                    GL.GetDouble(GetPName.ProjectionMatrix, out projection_matrix);//Загружаем матрицу проецирования в projection_matrix
//
////Подготавливаем матрицу поворота вокруг оси OZ                
//                    double cos = Math.Cos(x_angle * Math.PI / 180);
//                    double sin = Math.Sin(x_angle * Math.PI / 180);
//
//                    Matrix4d rotating_matrix = new Matrix4d(
//                        cos, -sin, 0, 0,
//                        sin, cos,  0, 0,
//                        0,     0,  1, 0,
//                        0,     0,  0, 1
//                    );
//
//                    projection_matrix *= rotating_matrix;//умножаем матрицу проецирования на матрицу поворота
//                    GL.MatrixMode(MatrixMode.Projection);//переходим в режим проецирования
//                    GL.LoadMatrix(ref projection_matrix);//устанавливаем новую матрицу проецирования
//                    }
                        //GL.Rotate(x_angle, rotate_matrix[0], rotate_matrix[1], rotate_matrix[2]);
                    GL.Rotate(x_angle, 0.0f, 1.0f, 0.0f);
                    GL.Rotate(x_angle, 1.0f, 0.0f, 0.0f);
                    //GL.Rotate(x_angle, 0.0f, 0.0f, 1.0f);
                    drawCube(width, 0, 0, 0);
                    drawCube(width, 0, width, 0);
                    drawCube(width, width, 0, 0);
                    drawCube(width, -width, 0, 0);
            /*задняя*/
//            GL.Color3(Color.Red);
//            GL.Begin(BeginMode.Polygon);
//            GL.Vertex3(0, 0, 0);
//            GL.Vertex3(width, 0, 0);
//            GL.Vertex3(width, width, 0);
//            GL.Vertex3(0, width, 0);
//            GL.End();
//
//            /*левая*/
//            GL.Begin(BeginMode.Polygon);
//            
//            GL.Vertex3(0, 0, 0);
//            GL.Vertex3(0, 0, width);
//            GL.Vertex3(0, width, width);
//            GL.Vertex3(0, width, 0);
//            GL.End();
//
//            /*нижняя*/
//            GL.Begin(BeginMode.Polygon);
//            GL.Vertex3(0, 0, 0);
//            GL.Vertex3(0, 0, width);
//            GL.Vertex3(width, 0, width);
//            GL.Vertex3(width, 0, 0);
//            GL.End();
//
//            /*верхняя*/
//            GL.Begin(BeginMode.Polygon);
//            GL.Vertex3(0, width, 0);
//            GL.Vertex3(0, width, width);
//            GL.Vertex3(width, width, width);
//            GL.Vertex3(width, width, 0);
//            GL.End();
//
//            /*передняя*/            
//            GL.Begin(BeginMode.Polygon);
//            GL.Vertex3(0, 0, width);
//            GL.Vertex3(width, 0, width);
//            GL.Vertex3(width, width, width);
//            GL.Vertex3(0, width, width);
//            GL.End();
//
//            /*правая*/
//            GL.Begin(BeginMode.Polygon);
//            GL.Vertex3(width, 0, 0);
//            GL.Vertex3(width, 0, width);
//            GL.Vertex3(width, width, width);
//            GL.Vertex3(width, width, 0);
//            GL.End();
//
//			/*ребра*/
//            GL.Color3(Color.Black);
//            GL.Begin(BeginMode.LineLoop);
//            GL.Vertex3(0, 0, 0);
//            GL.Vertex3(0, width, 0);
//            GL.Vertex3(width, width, 0);
//            GL.Vertex3(width, 0, 0);
//            GL.End();
//
//            GL.Begin(BeginMode.LineLoop);
//            GL.Vertex3(width, 0, 0);
//            GL.Vertex3(width, 0, width);
//            GL.Vertex3(width, width, width);
//            GL.Vertex3(width, width, 0);
//            GL.End();
//
//            GL.Begin(BeginMode.LineLoop);
//            GL.Vertex3(0, 0, width);
//            GL.Vertex3(width, 0, width);
//            GL.Vertex3(width, width, width);
//            GL.Vertex3(0, width, width);
//            GL.End();
//
//            GL.Begin(BeginMode.LineLoop);
//            GL.Vertex3(0, 0, 0);
//            GL.Vertex3(0, 0, width);
//            GL.Vertex3(0, width, width);
//            GL.Vertex3(0, width, 0);
//            GL.End();
//                    
//                    
//            GL.Color3(Color.Red);
//            GL.Begin(BeginMode.Polygon);
//            GL.Vertex3(0, width, 0);
//            GL.Vertex3(width, width, 0);
//            GL.Vertex3(width, width + width, 0);
//            GL.Vertex3(0, width + width, 0);
//            GL.End();
//
//            /*левая*/
//            GL.Begin(BeginMode.Polygon);
//            
//            GL.Vertex3(0, width, 0);
//            GL.Vertex3(0, width, width);
//            GL.Vertex3(0, width + width, width);
//            GL.Vertex3(0, width + width, 0);
//            GL.End();
//
//            /*нижняя*/
//            GL.Begin(BeginMode.Polygon);
//            GL.Vertex3(0, width, 0);
//            GL.Vertex3(0, width, width);
//            GL.Vertex3(width, width, width);
//            GL.Vertex3(width, width, 0);
//            GL.End();
//
//            /*верхняя*/
//            GL.Begin(BeginMode.Polygon);
//            GL.Vertex3(0, width + width, 0);
//            GL.Vertex3(0, width + width, width);
//            GL.Vertex3(width, width + width, width);
//            GL.Vertex3(width, width + width, 0);
//            GL.End();
//
//            /*передняя*/            
//            GL.Begin(BeginMode.Polygon);
//            GL.Vertex3(0, width, width);
//            GL.Vertex3(width, width, width);
//            GL.Vertex3(width, width + width, width);
//            GL.Vertex3(0, width + width, width);
//            GL.End();
//
//            /*правая*/
//            GL.Begin(BeginMode.Polygon);
//            GL.Vertex3(width, width, 0);
//            GL.Vertex3(width, width, width);
//            GL.Vertex3(width, width + width, width);
//            GL.Vertex3(width, width + width, 0);
//            GL.End();
//
//			/*ребра*/
//            GL.Color3(Color.Black);
//            GL.Begin(BeginMode.LineLoop);
//            GL.Vertex3(0, width, 0);
//            GL.Vertex3(0, width + width, 0);
//            GL.Vertex3(width, width + width, 0);
//            GL.Vertex3(width, width, 0);
//            GL.End();
//
//            GL.Begin(BeginMode.LineLoop);
//            GL.Vertex3(width, width, 0);
//            GL.Vertex3(width, width, width);
//            GL.Vertex3(width, width + width, width);
//            GL.Vertex3(width, width + width, 0);
//            GL.End();
//
//            GL.Begin(BeginMode.LineLoop);
//            GL.Vertex3(0, width, width);
//            GL.Vertex3(width, width, width);
//            GL.Vertex3(width, width + width, width);
//            GL.Vertex3(0, width + width, width);
//            GL.End();
//
//            GL.Begin(BeginMode.LineLoop);
//            GL.Vertex3(0, width, 0);
//            GL.Vertex3(0,  width, width);
//            GL.Vertex3(0, width + width, width);
//            GL.Vertex3(0, width + width, 0);
//            GL.End();
                    
                    
 
                    game.SwapBuffers();
                    
                };
 
                // Run the game at 60 updates per second
                game.Run(60.0);
            }
        }

        private static void drawCube(float width, float x, float y, float z)
        {
            /*задняя*/
            GL.Color3(Color.Red);
            GL.Begin(BeginMode.Polygon);
            GL.Vertex3(x, y, z);
            GL.Vertex3(x + width, y, z);
            GL.Vertex3(x + width, y + width, z);
            GL.Vertex3(x, y + width, z);
            GL.End();

            /*левая*/
            GL.Begin(BeginMode.Polygon);
            
            GL.Vertex3(x, y, z);
            GL.Vertex3(x, y, z + width);
            GL.Vertex3(x, y + width, z + width);
            GL.Vertex3(x, y + width, z);
            GL.End();

            /*нижняя*/
            GL.Begin(BeginMode.Polygon);
            GL.Vertex3(x, y, z);
            GL.Vertex3(x, y, z + width);
            GL.Vertex3(x + width, y, z + width);
            GL.Vertex3(x + width, y, z);
            GL.End();

            /*верхняя*/
            GL.Begin(BeginMode.Polygon);
            GL.Vertex3(x, y + width, z);
            GL.Vertex3(x, y + width, z + width);
            GL.Vertex3(x + width, y + width, z + width);
            GL.Vertex3(x + width, y + width, z);
            GL.End();

            /*передняя*/            
            GL.Begin(BeginMode.Polygon);
            GL.Vertex3(x, y, z + width);
            GL.Vertex3(x + width, y, z + width);
            GL.Vertex3(x + width, y + width, z + width);
            GL.Vertex3(x, y + width, z + width);
            GL.End();

            /*правая*/
            GL.Begin(BeginMode.Polygon);
            GL.Vertex3(x + width, y, z);
            GL.Vertex3(x + width, y, z + width);
            GL.Vertex3(x + width, y + width, z + width);
            GL.Vertex3(z + width, z + width, z);
            GL.End();

			/*ребра*/
            GL.Color3(Color.Black);
            GL.Begin(BeginMode.LineLoop);
            GL.Vertex3(x, y, z);
            GL.Vertex3(x, y + width, z);
            GL.Vertex3(x + width, y + width, z);
            GL.Vertex3(x + width, y, z);
            GL.End();

            GL.Begin(BeginMode.LineLoop);
            GL.Vertex3(x + width, y, z);
            GL.Vertex3(x + width, y, z + width);
            GL.Vertex3(x + width, y + width, z + width);
            GL.Vertex3(x + width, y + width, z);
            GL.End();

            GL.Begin(BeginMode.LineLoop);
            GL.Vertex3(x, y, z + width);
            GL.Vertex3(x + width, y, z + width);
            GL.Vertex3(x + width, y + width, z + width);
            GL.Vertex3(x, y + width, z + width);
            GL.End();

            GL.Begin(BeginMode.LineLoop);
            GL.Vertex3(x, y, z);
            GL.Vertex3(x, y, z + width);
            GL.Vertex3(x, y + width, z + width);
            GL.Vertex3(x, y + width, z);
            GL.End();
        }
    }
}