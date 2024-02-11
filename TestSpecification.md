given "" to CheckoutBillCalculator() then 0

given "A" to CheckoutBillCalculator() then 50
given "B" to CheckoutBillCalculator() then 30
given "C" to CheckoutBillCalculator() then 20
given "D" to CheckoutBillCalculator() then 15

given "ABC" to CheckoutBillCalculator() then 100
given "DAB" to CheckoutBillCalculator() then 95

given "ABAAC" to CheckoutBillCalculator() then 180
given "ABDBADC" to CheckoutBillCalculator() then 195
given "ABADBAABAAA" to CheckoutBillCalculator() then 400

given "EFGG" to CheckoutBillCalculator() then throws Exception
given "123123" to CheckoutBillCalculator() then throws Exception
given "2184u12" to CheckoutBillCalculator() then throws Exception
given "abcd" to CheckoutBillCalculator() then throws Exception