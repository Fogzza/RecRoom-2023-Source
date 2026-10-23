    // Additional original12 observations; only called inside the real player.
    void InitializerPrerequisites(UniversalRenderPipelineAsset asset)
    {
        var capture=typeof(CameraCaptureBridge);var dictionary=Field(capture,"actionDict");var captured=dictionary.GetValue(null);
        Check(captured!=null&&((System.Collections.IDictionary)captured).Count==0&&!CameraCaptureBridge.enabled,"original_capture_dictionary_cctor_empty_and_enabled_false");
        CameraCaptureBridge.enabled=true;Check(CameraCaptureBridge.enabled&&ReferenceEquals(captured,dictionary.GetValue(null)),"original_capture_enabled_true_same_dictionary");
        CameraCaptureBridge.enabled=false;Check(!CameraCaptureBridge.enabled&&ReferenceEquals(captured,dictionary.GetValue(null)),"original_capture_enabled_false_same_dictionary");
        var t=typeof(UniversalRenderPipelineAsset);var field=Field(t,"m_RenderFeatureset");field.SetValue(asset,Enum.ToObject(field.FieldType,123));Check(Convert.ToInt32(Call(Method(t,"get_renderFeatureset"),asset))==123,"original_asset_renderFeatureset_raw_enum_field");
        field=Field(t,"m_PostProcessing");field.SetValue(asset,Enum.ToObject(field.FieldType,-456));Check(Convert.ToInt32(Call(Method(t,"get_postProcessing"),asset))==-456,"original_asset_postProcessing_raw_enum_field");
        Field(t,"m_SupportsHDR").SetValue(asset,true);bool hdr=(bool)Call(Method(t,"get_supportsHDR"),asset);Field(t,"m_SupportsHDR").SetValue(asset,false);Check(hdr&&!(bool)Call(Method(t,"get_supportsHDR"),asset),"original_asset_supportsHDR_true_false");
        field=Field(t,"m_MSAA");field.SetValue(asset,Enum.ToObject(field.FieldType,4));Check((int)Call(Method(t,"get_msaaSampleCount"),asset)==4,"original_asset_msaa_original_enum_int_conversion");
        Field(t,"m_RenderScale").SetValue(asset,-0.0f);float scale=(float)Call(Method(t,"get_renderScale"),asset);Check(BitConverter.ToInt32(BitConverter.GetBytes(scale),0)==unchecked((int)0x80000000),"original_asset_renderScale_negative_zero_bits");
        Field(t,"m_RecRoomQualityConfig").SetValue(asset,null);Check(Call(Method(t,"get_RecRoomQualityConfig"),asset)==null,"original_asset_RecRoomQualityConfig_null_preserved");
        var utils=typeof(RenderingUtils);var rf=Field(utils,"m_RenderTextureFormatSupport");var gf=Field(utils,"m_GraphicsFormatSupport");var oldR=rf.GetValue(null);var oldG=gf.GetValue(null);
        var r=new Dictionary<RenderTextureFormat,bool>{{RenderTextureFormat.Default,true}};var g=new Dictionary<UnityEngine.Experimental.Rendering.GraphicsFormat,Dictionary<UnityEngine.Experimental.Rendering.FormatUsage,bool>>{{UnityEngine.Experimental.Rendering.GraphicsFormat.None,new Dictionary<UnityEngine.Experimental.Rendering.FormatUsage,bool>()}};
        try
        {
            rf.SetValue(null,r);gf.SetValue(null,g);Call(Method(utils,"ClearSystemInfoCache"),null);Check(r.Count==0&&g.Count==0,"original_cache_clear_both_real_BCL_dictionaries");
            Check(ReferenceEquals(r,rf.GetValue(null))&&ReferenceEquals(g,gf.GetValue(null)),"original_cache_clear_keeps_original_dictionary_references");
            g[UnityEngine.Experimental.Rendering.GraphicsFormat.None]=new Dictionary<UnityEngine.Experimental.Rendering.FormatUsage,bool>();rf.SetValue(null,null);bool threw=false;try{Call(Method(utils,"ClearSystemInfoCache"),null);}catch(NullReferenceException){threw=true;}Check(threw&&g.Count==1,"original_cache_first_null_prevents_second_clear");
            rf.SetValue(null,r);r[RenderTextureFormat.Default]=true;gf.SetValue(null,null);threw=false;try{Call(Method(utils,"ClearSystemInfoCache"),null);}catch(NullReferenceException){threw=true;}Check(threw&&r.Count==0,"original_cache_second_null_follows_first_clear");
        }
        finally{rf.SetValue(null,oldR);gf.SetValue(null,oldG);}
        var generated=typeof(UniversalRenderPipeline).GetNestedType("<>c",BindingFlags.NonPublic);Need(generated!=null,"Exact existing generated callback owner");var callback=Activator.CreateInstance(generated,true);var comparison=Method(generated,"<.ctor>b__32_0");var lights=Method(generated,"<.cctor>b__73_0");
        GameObject cameraA=null,cameraB=null,lightA=null,lightB=null;
        try
        {
            cameraA=new GameObject("OriginalComparisonA");cameraB=new GameObject("OriginalComparisonB");var ca=cameraA.AddComponent<Camera>();var cb=cameraB.AddComponent<Camera>();ca.enabled=false;cb.enabled=false;ca.depth=1.9f;cb.depth=1.2f;
            Check((int)Call(comparison,callback,ca,cb)==0,"original_camera_comparison_casts_each_real_depth_before_subtraction");cb.depth=-1.2f;Check((int)Call(comparison,callback,ca,cb)==2,"original_camera_comparison_mixed_sign_real_engine_depths");
            Call(lights,callback,new Light[0],default(Unity.Collections.NativeArray<UnityEngine.Experimental.GlobalIllumination.LightDataGI>));Check(true,"original_light_callback_empty_input_no_native_array_write");
            lightA=new GameObject("OriginalLightRequestA");lightB=new GameObject("OriginalLightRequestB");var la=lightA.AddComponent<Light>();var lb=lightB.AddComponent<Light>();la.enabled=false;lb.enabled=false;
            var output=new Unity.Collections.NativeArray<UnityEngine.Experimental.GlobalIllumination.LightDataGI>(3,Unity.Collections.Allocator.Temp);
            try
            {
                Call(lights,callback,new[]{la,lb},output);Check(output[0].instanceID==la.GetInstanceID()&&output[1].instanceID==lb.GetInstanceID(),"original_light_callback_real_instance_ids_and_native_array_output_order");
                Check(output[2].instanceID==0,"original_light_callback_unselected_native_array_tail_unchanged");
            }
            finally{output.Dispose();}
        }
        finally{if(cameraA!=null)Destroy(cameraA);if(cameraB!=null)Destroy(cameraB);if(lightA!=null)Destroy(lightA);if(lightB!=null)Destroy(lightB);}
    }
