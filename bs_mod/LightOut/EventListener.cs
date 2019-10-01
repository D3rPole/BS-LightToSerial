using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;

namespace LightOut
{
    class EventListener : MonoBehaviour
    {
        private SerialPort port;
        private BeatmapObjectCallbackController Ec;
        private ColorManager Cm;
        private BeatmapLevelSO BMD;
        private int BPM;
        private Color C1;
        private Color C2;
        void Awake()
        {
            port = new SerialPort("COM" + Config.comPort, Config.baudRate, Parity.None, 8, StopBits.One);
            Debug.Log("COM" + Config.comPort);
            port.Open();
            StartCoroutine(GrabLight());
        }

        IEnumerator GrabLight()
        {
            yield return new WaitUntil(() => Resources.FindObjectsOfTypeAll<BeatmapObjectCallbackController>().Any());
            Ec = Resources.FindObjectsOfTypeAll<BeatmapObjectCallbackController>().FirstOrDefault();
            StartCoroutine(GrabColors());
        }
        IEnumerator GrabColors()
        {
            yield return new WaitUntil(() => Resources.FindObjectsOfTypeAll<ColorManager>().Any());
            Cm = Resources.FindObjectsOfTypeAll<ColorManager>().FirstOrDefault();
            StartCoroutine(GetBPM());
        }
        IEnumerator GetBPM()
        {
            yield return new WaitUntil(() => Resources.FindObjectsOfTypeAll<BeatmapLevelSO>().Any());
            BMD = Resources.FindObjectsOfTypeAll<BeatmapLevelSO>().FirstOrDefault();
            Init();
        }

        void Init()
        {
            Ec.beatmapEventDidTriggerEvent += EventHappened;

            C1 = Cm.ColorForNoteType(NoteType.NoteA);
            C2 = Cm.ColorForNoteType(NoteType.NoteB);

            BPM = (int)BMD.beatsPerMinute;

            port.WriteLine("C1/" + (int)(C1.r * 255) + "/" + (int)(C1.g * 255) + "/" + (int)(C1.b * 255));
            port.WriteLine("C2/" + (int)(C2.r * 255) + "/" + (int)(C2.g * 255) + "/" + (int)(C2.b * 255));

            port.WriteLine("BPM/" + BPM);

            Debug.Log("C1/" + (int)(C1.r * 255) + "/" + (int)(C1.g * 255) + "/" + (int)(C1.b * 255));
            Debug.Log("C2/" + (int)(C2.r * 255) + "/" + (int)(C2.g * 255) + "/" + (int)(C2.b * 255));
        }

        void OnDestroy()
        {
            port.Close();
        }

        void EventHappened(BeatmapEventData Data)
        {
            port.WriteLine(Data.type.ToString().Replace("Event","") + "/" + Data.value);
            
            //Debug.Log(Data.type.ToString().Replace("Event", "") + "/" + Data.value);
        }
    }
}
