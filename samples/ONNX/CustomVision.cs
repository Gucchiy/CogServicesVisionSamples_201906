// This file was automatically generated by VS extension Windows Machine Learning Code Generator v3
// from model file CustomVision.onnx
// Warning: This file may get overwritten if you add add an onnx file with the same name
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Media;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.AI.MachineLearning;
namespace CustomVisionONNXAppSample_201907
{
    
    public sealed class CustomVisionInput
    {
        //public ImageFeatureValue data; // BitmapPixelFormat: Bgra8, BitmapAlphaMode: Premultiplied, width: 224, height: 224
        // Modified
        public VideoFrame data; // BitmapPixelFormat: Bgra8, BitmapAlphaMode: Premultiplied, width: 224, height: 224
    }
    
    public sealed class CustomVisionOutput
    {
        public TensorString classLabel = TensorString.Create(new long[] { 1, 1 });
        public IList<IDictionary<string,float>> loss = new List<IDictionary<string, float>>();
    }
    
    public sealed class CustomVisionModel
    {
        private LearningModel model;
        private LearningModelSession session;
        private LearningModelBinding binding;

        public static async Task<CustomVisionModel> CreateFromStreamAsync(IRandomAccessStreamReference stream)
        {
            CustomVisionModel learningModel = new CustomVisionModel();
            learningModel.model = await LearningModel.LoadFromStreamAsync(stream);
            learningModel.session = new LearningModelSession(learningModel.model);
            learningModel.binding = new LearningModelBinding(learningModel.session);
            return learningModel;
        }
        public async Task<CustomVisionOutput> EvaluateAsync(CustomVisionInput input)
        {
            binding.Bind("data", input.data);
            var result = await session.EvaluateAsync(binding, "0");
            var output = new CustomVisionOutput();
            output.classLabel = result.Outputs["classLabel"] as TensorString;
            output.loss = result.Outputs["loss"] as IList<IDictionary<string,float>>;
            return output;
        }

        // Added
        public static async Task<CustomVisionModel> CreateFromFileAsync(StorageFile file)
        {
            CustomVisionModel learningModel = new CustomVisionModel();
            learningModel.model = await LearningModel.LoadFromStorageFileAsync(file);
            learningModel.session = new LearningModelSession(learningModel.model);
            learningModel.binding = new LearningModelBinding(learningModel.session);
            return learningModel;
        }

    }
}

