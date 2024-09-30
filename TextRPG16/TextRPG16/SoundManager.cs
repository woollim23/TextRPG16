using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using NAudio.Wave;

namespace TextRPG16
{
    public class SoundManager
    {
        public SoundManager() 
        {

        }

        public void SoundEffectUseRest() // 회복 끝날때 나올 효과음
        {
            // 효과음 파일 경로 설정
            string _soundFilePath = @"C:\Git\TextRPG16\TextRPG16\TextRPG16\bin\Debug\net6.0\Pokemon-Platinum-Recovery"; // bin\Debug\net6.0파일에 효과음 몇개 추가 했습니다.

            try
            {
                using (var _audioFile = new AudioFileReader(_soundFilePath))
                using (var _outputDevice = new WaveOutEvent())
                {
                    _outputDevice.Init(_audioFile);
                    _outputDevice.Play();
                    while (_outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        // 재생이 끝날 때까지 대기
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"효과음 재생 중 오류 발생: {ex.Message}");
            }
        }


        public void WarriorSkill1() // 전사 스킬 나올때 효과음1
        {
            // 효과음 파일 경로 설정
            string _soundFilePath = @"C:\Git\TextRPG16\TextRPG16\TextRPG16\bin\Debug\net6.0\Pokemon-Platinum-Recovery"; // bin\Debug\net6.0파일에 효과음 몇개 추가 했습니다.

            try
            {
                using (var _audioFile = new AudioFileReader(_soundFilePath))
                using (var _outputDevice = new WaveOutEvent())
                {
                    _outputDevice.Init(_audioFile);
                    _outputDevice.Play();
                    while (_outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        // 재생이 끝날 때까지 대기
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"효과음 재생 중 오류 발생: {ex.Message}");
            }
        }

        public void WarrorSkill2() // 전사 스킬 나올때 효과음2
        {
            // 효과음 파일 경로 설정
            string _soundFilePath = @"C:\Git\TextRPG16\TextRPG16\TextRPG16\bin\Debug\net6.0\Pokemon-Platinum-Recovery"; // bin\Debug\net6.0파일에 효과음 몇개 추가 했습니다.

            try
            {
                using (var _audioFile = new AudioFileReader(_soundFilePath))
                using (var _outputDevice = new WaveOutEvent())
                {
                    _outputDevice.Init(_audioFile);
                    _outputDevice.Play();
                    while (_outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        // 재생이 끝날 때까지 대기
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"효과음 재생 중 오류 발생: {ex.Message}");
            }
        }


        public void AcherSkill1() // 아처 스킬 나올때 효과음1
        {
            // 효과음 파일 경로 설정
            string _soundFilePath = @"C:\Git\TextRPG16\TextRPG16\TextRPG16\bin\Debug\net6.0\Pokemon-Platinum-Recovery"; // bin\Debug\net6.0파일에 효과음 몇개 추가 했습니다.

            try
            {
                using (var _audioFile = new AudioFileReader(_soundFilePath))
                using (var _outputDevice = new WaveOutEvent())
                {
                    _outputDevice.Init(_audioFile);
                    _outputDevice.Play();
                    while (_outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        // 재생이 끝날 때까지 대기
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"효과음 재생 중 오류 발생: {ex.Message}");
            }
        }

        public void AcharSkill2() // 아처 스킬 나올때 나올 효과음2
        {
            // 효과음 파일 경로 설정
            string _soundFilePath = @"C:\Git\TextRPG16\TextRPG16\TextRPG16\bin\Debug\net6.0\Pokemon-Platinum-Recovery"; // bin\Debug\net6.0파일에 효과음 몇개 추가 했습니다.

            try
            {
                using (var _audioFile = new AudioFileReader(_soundFilePath))
                using (var _outputDevice = new WaveOutEvent())
                {
                    _outputDevice.Init(_audioFile);
                    _outputDevice.Play();
                    while (_outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        // 재생이 끝날 때까지 대기
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"효과음 재생 중 오류 발생: {ex.Message}");
            }
        }


        public void WizardSkill1() // 마법사 스킬  나올때 효과음1
        {
            // 효과음 파일 경로 설정
            string _soundFilePath = @"C:\Git\TextRPG16\TextRPG16\TextRPG16\bin\Debug\net6.0\Pokemon-Platinum-Recovery"; // bin\Debug\net6.0파일에 효과음 몇개 추가 했습니다.

            try
            {
                using (var _audioFile = new AudioFileReader(_soundFilePath))
                using (var _outputDevice = new WaveOutEvent())
                {
                    _outputDevice.Init(_audioFile);
                    _outputDevice.Play();
                    while (_outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        // 재생이 끝날 때까지 대기
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"효과음 재생 중 오류 발생: {ex.Message}");
            }
        }

        public void WizardSkill2() // 마법사 스킬 나올때 효과음2
        {
            // 효과음 파일 경로 설정
            string _soundFilePath = @"C:\Git\TextRPG16\TextRPG16\TextRPG16\bin\Debug\net6.0\Pokemon-Platinum-Recovery"; // bin\Debug\net6.0파일에 효과음 몇개 추가 했습니다.

            try
            {
                using (var _audioFile = new AudioFileReader(_soundFilePath))
                using (var _outputDevice = new WaveOutEvent())
                {
                    _outputDevice.Init(_audioFile);
                    _outputDevice.Play();
                    while (_outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        // 재생이 끝날 때까지 대기
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"효과음 재생 중 오류 발생: {ex.Message}");
            }
        }

        public void ThiefSkill1() // 도둑 스킬 나올때 효과음1
        {
            // 효과음 파일 경로 설정
            string _soundFilePath = @"C:\Git\TextRPG16\TextRPG16\TextRPG16\bin\Debug\net6.0\Pokemon-Platinum-Recovery"; // bin\Debug\net6.0파일에 효과음 몇개 추가 했습니다.

            try
            {
                using (var _audioFile = new AudioFileReader(_soundFilePath))
                using (var _outputDevice = new WaveOutEvent())
                {
                    _outputDevice.Init(_audioFile);
                    _outputDevice.Play();
                    while (_outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        // 재생이 끝날 때까지 대기
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"효과음 재생 중 오류 발생: {ex.Message}");
            }
        }

        public void ThiefSkill2() //  도둑 스킬 나올때 효과음2
        {
            // 효과음 파일 경로 설정
            string _soundFilePath = @"C:\Git\TextRPG16\TextRPG16\TextRPG16\bin\Debug\net6.0\Pokemon-Platinum-Recovery"; // bin\Debug\net6.0파일에 효과음 몇개 추가 했습니다.

            try
            {
                using (var _audioFile = new AudioFileReader(_soundFilePath))
                using (var _outputDevice = new WaveOutEvent())
                {
                    _outputDevice.Init(_audioFile);
                    _outputDevice.Play();
                    while (_outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        // 재생이 끝날 때까지 대기
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"효과음 재생 중 오류 발생: {ex.Message}");
            }
        }

        public void PriestSkill1() //  프리스트 스킬 나올때 효과음1
        {
            // 효과음 파일 경로 설정
            string _soundFilePath = @"C:\Git\TextRPG16\TextRPG16\TextRPG16\bin\Debug\net6.0\Pokemon-Platinum-Recovery"; // bin\Debug\net6.0파일에 효과음 몇개 추가 했습니다.

            try
            {
                using (var _audioFile = new AudioFileReader(_soundFilePath))
                using (var _outputDevice = new WaveOutEvent())
                {
                    _outputDevice.Init(_audioFile);
                    _outputDevice.Play();
                    while (_outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        // 재생이 끝날 때까지 대기
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"효과음 재생 중 오류 발생: {ex.Message}");
            }
        }


        public void PriestSkill2() //  프리스트 스킬 나올때 효과음2
        {
            // 효과음 파일 경로 설정
            string _soundFilePath = @"C:\Git\TextRPG16\TextRPG16\TextRPG16\bin\Debug\net6.0\Pokemon-Platinum-Recovery"; // bin\Debug\net6.0파일에 효과음 몇개 추가 했습니다.

            try
            {
                using (var _audioFile = new AudioFileReader(_soundFilePath))
                using (var _outputDevice = new WaveOutEvent())
                {
                    _outputDevice.Init(_audioFile);
                    _outputDevice.Play();
                    while (_outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        // 재생이 끝날 때까지 대기
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"효과음 재생 중 오류 발생: {ex.Message}");
            }
        }
    }

    
} 

    

