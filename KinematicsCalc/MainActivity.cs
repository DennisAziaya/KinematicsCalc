using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);



            _textViewchooseVariable = FindViewById<TextView>(Resource.Id.txtChooseVariable);
            _textViewChooseCalculation = FindViewById<TextView>(Resource.Id.txtChooseCalculation);
            _editTextField1 = FindViewById<EditText>(Resource.Id.txtField1);
            _editTextField2 = FindViewById<EditText>(Resource.Id.txtField2);
            _editTextField3 = FindViewById<EditText>(Resource.Id.txtField3);
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
                "d = vi*t",
                "Initial velocity",
                "Acceleration",
                "Displacement",
                "Time"
            };

            _buttonCalculate.Click += _buttonCalculate_Click;
        }

        private void _buttonCalculate_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}