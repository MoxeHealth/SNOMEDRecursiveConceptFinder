SNOMED Recursive Concept Finder by Mark Olschesky, Moxe Health

The best way to know what a disease is for decision support purposes in an HIS system is to get the SNOMED concept for a certain diagnosis, then find all of the children SNOMED concepts for that diagnosis. 

For example. Let's say that you want your decison support system to do something when a patient has "Diabetes". There are MANY diagnoses and SNOMED codes that make up diabetes. Here's how to use the tool:

1) To use SNOMED as dictated by license, you should register for a UMLS license from NIH. You will also need to get a user ID and GUID from Snoflake, the providers of the API that powers our concept finder.

https://uts.nlm.nih.gov//snomedctBrowser.html -- NIH signup for SNOMED licensing.

http://snomed.dataline.co.uk/ -- Snoflake registration

2) Did you register OK? Great, let's get started.

Go to either the SNOMED CT Browser or the Snoflake browser online and find the parent concept that you are looking for. In our case, Diabetes Mellitus is 73211009. Write this down. A future enhancement would be to do this in the recursive browser tool, but I recommend using the visual toolset online. It'll help you know if you found the right level of concept; you do not want to accidentally pick something too broad or too vague.

3) Substitute the placeholder GUID in program.cs

    string guid = "GUID"; //Enter your GUID here

If you don't do this, a FaultException will be thrown by the program.

4) Run the console program. Enter your concept entered above and you'll be given a comma delimited list of all child concepts.

5) I would recommend finding a clinician to review the output of your SNOMED findings. A broad concept search like this can work very well for certain diagnoses and medical families but works worse for others (Mental Health diagnoses come to mind).


There is plenty of room for future enhancements, but this is a start. If you have any questions, problems or suggestions, contact mark@moxehealth.com. The code uses the MIT license, so share kindly.