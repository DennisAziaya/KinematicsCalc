using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace KinematicsCalc
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView _textViewchooseVariable;
        private TextView _textViewChooseCalculation;
        private EditText _editTextField1;
        private EditText _editTextField2;
        private EditText _editTextField3;
        private Button _buttonCalculate;
        private TextView _textViewResult;
        private Spinner _spinnerChooseVariable;
        private Spinner _spinnerChooseCalculation;

        private string[] listOfMissingVariable;
        private string[] listOfCalculations;

        private double finalAnswer;
        private double variable1;
        private double variable2;
        private double variable3;

        private string variableToCalculate;
        private string calculationToUse;
        private string combined_strings;
        private string units;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);



            _textViewchooseVariable = FindViewById<TextView>(Resource.Id.txtChooseVariable);
            _textViewChooseCalculation = FindViewById<TextView>(Resource.Id.txtChooseCalculation);
            _editTextField1 = FindViewById<EditText>(Resource.Id.editTxtField1);
            _editTextField2 = FindViewById<EditText>(Resource.Id.editTxtField2);
            _editTextField3 = FindViewById<EditText>(Resource.Id.editTxtField3);
            _textViewResult = FindViewById<TextView>(Resource.Id.txtResult);
            _buttonCalculate = FindViewById<Button>(Resource.Id.btnCalculate);
            _spinnerChooseCalculation = FindViewById<Spinner>(Resource.Id.spnChooseCalculation);
            _spinnerChooseVariable = FindViewById<Spinner>(Resource.Id.spnChooseCalculation);

            listOfMissingVariable = new string[]
            {
                "choose missing variable",
                "Final velocity",
                "Initial velocity",
                "Acceleration",
                "Displacement",
                "Time"
            };

            listOfCalculations = new string[]
            {
                "choose missing variable",
                "d = vi*t+0.5*a*t^2",
                "vf^2 = vi^2 + 2*a*d",
                "vf = vi + a*t",
                "d = 0.5*(vi=vf)*t"
            };

            _buttonCalculate.Click += _buttonCalculate_Click;
        }

        private void _buttonCalculate_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        void setMissingVariableSpinner()
        {
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, listOfMissingVariable);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _spinnerChooseVariable.Adapter = adapter;
        }

        void chooseFromMissingVariableSpinner()
        {
            _spinnerChooseVariable.ItemSelected += _spinnerChooseVariable_ItemSelected;
        }

        private void _spinnerChooseVariable_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            variableToCalculate = _spinnerChooseVariable.SelectedItem.ToString();
            _textViewchooseVariable.Text = variableToCalculate;
            chooseFromCalculationSpinner();
        }

        void setCalculationVariableSpinner()
        {
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, listOfCalculations);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _spinnerChooseCalculation.Adapter = adapter;
        }

        void chooseFromCalculationSpinner()
        {
            _spinnerChooseCalculation.ItemSelected += _spinnerChooseCalculation_ItemSelected;
        }

        private void _spinnerChooseCalculation_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            calculationToUse = _spinnerChooseCalculation.SelectedItem.ToString();
            _textViewChooseCalculation.Text = calculationToUse;
            chooseCalculation(calculationToUse);
        }

        void chooseCalculation(string calculation)
        {
            switch (variableToCalculate)
            {
                case "Final velocity":
                    chooseFinalVelocityCalculation(calculation);
                    break;

                case "Initial velocity":
                    chooseInitialVelocityCalculation(calculation);
                    break;

                case "Acceleration":
                    chooseAccelerationCalculation(calculation);
                    break;

                case "Displacement":
                    chooseDisplacementCalculation(calculation);
                    break;

                case "Time":
                    chooseTimeCalculation(calculation);
                    break;
            }
        }


        void chooseFinalVelocityCalculation(string calculation)
        {
            switch (calculation)
            {
                case"vf^2 = vi^2 + 2*a*d":
                    combined_strings = SetHints("vi", "a", "d");
                    break;
                
                case "vf = vi + a*t":
                    combined_strings = SetHints("vi", "a", "t");
                    break;

                case "d = 0.5*(vi=vf)*t":
                    combined_strings = SetHints("vi", "d", "t");
                    break;
            }
            CalculateFinalVelocity(combined_strings);
        } 

        void chooseInitialVelocityCalculation(string calculation)
        {

            switch (calculation)
            {
                case "d = vi*t+0.5*a*t^2":
                    combined_strings = SetHints( "a", "d", "t");
                    break;

                case "vf^2 = vi^2 + 2*a*d":
                    combined_strings = SetHints("vf", "a", "d");
                    break;

                case "vf = vi + a*t":
                    combined_strings = SetHints("vf", "a", "t");
                    break;

                case "d = 0.5*(vi=vf)*t":
                    combined_strings = SetHints("vf", "d", "t");
                    break;
            }
            CalculateInitialVelocity(combined_strings);


        }

        void chooseAccelerationCalculation(string calculation)
        {


            switch (calculation)
            {
                case "d = vi*t+0.5*a*t^2":
                    combined_strings = SetHints( "vi", "d", "t");
                    break;

                case "vf^2 = vi^2 + 2*a*d":
                    combined_strings = SetHints("vf", "vi", "d");
                    break;

                case "vf = vi + a*t":
                    combined_strings = SetHints("vf", "vi", "t");
                    break;

            }
            CalculateAcceleration(combined_strings);

        }

        void chooseDisplacementCalculation(string calculation)
        {

            switch (calculation)
            {
                case "d = vi*t+0.5*a*t^2":
                    combined_strings = SetHints("vi", "a", "t");
                    break;

                case "vf^2 = vi^2 + 2*a*d":
                    combined_strings = SetHints("vf", "vi", "a");
                    break;

                case "d = 0.5*(vi=vf)*t":
                    combined_strings = SetHints("vf", "vi", "t");
                    break;
            }
            CalculateDisplacement(combined_strings);


        }

        void chooseTimeCalculation(string calculation)
        {

            switch (calculation)
            {
               
                case "vf = vi + a*t":
                    combined_strings = SetHints("vf", "vi", "a");
                    break;

                case "d = 0.5*(vi=vf)*t":
                    combined_strings = SetHints("vf", "vi", "d");
                    break;
            }
            CalculateTime(combined_strings);

        }




        void CalculateFinalVelocity(string variable)
        {

            ParseVariable();

            if(variable == "vi, a, d")
            {
                finalAnswer = Math.Pow((Math.Pow(variable1,2) + 2 * variable2 + variable3), 0.5);
            }
            else if (variable == "vi, a, t")
            {
                finalAnswer = variable1 + variable2 + variable3;
            }

            else if (variable == "vi, d, t")
            {
                finalAnswer = (2 * variable2 / variable3) - variable1;
            }

            units = "m/s";
            PrintResult();

        }

        void CalculateInitialVelocity(string variable)
        {

        }

        void CalculateAcceleration(string variable)
        {

        }

        void CalculateDisplacement(string variable)
        {

        }

        void CalculateTime(string variable)
        {

        }

        string SetHints(string variable_1, string variable_2, string variable_3)
        {

            _editTextField1.Hint = variable_1;
            _editTextField2.Hint = variable_2;
            _editTextField3.Hint = variable_3;

            _editTextField1.Hint = " ";
            _editTextField2.Hint = " ";
            _editTextField3.Hint = " ";

            return variable_1 + "," + variable_2 + "," + variable_3;


        }


        void ParseVariable()
        {
            variable1 = double.Parse(_editTextField1.Text);
            variable2 = double.Parse(_editTextField2.Text);
            variable3 = double.Parse(_editTextField3.Text);
        }

        void PrintResult()
        {
            answerText.text = finalAnswer.ToString() + " " + units;
        }
    }
}